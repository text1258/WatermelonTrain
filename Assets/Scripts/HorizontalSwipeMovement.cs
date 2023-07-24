using System;
using UnityEngine;
using YG;

public class HorizontalSwipeMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float limit;
    private Vector2 startClickPosition;
    private float step;
    private IInput input;
    private bool isMoving = false;
    private float ratio;
    public Action OnStartMove;
    public Action OnStopMove;
    private Transform selfTransform;

    public float Speed
    {
        get => speed;
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            speed = value;
        }
    }

    public bool IsMoving
    {
        get => isMoving; 
        set
        {
            if (value == true)
            {
                OnStartMove?.Invoke();
            }
            else
            {
                OnStopMove?.Invoke();
            }
            isMoving = value;
        }
    }

    private void Awake()
    {
        selfTransform = transform;
        if (IsMoving == true)
        {
            OnStartMove?.Invoke();
        }
        else
        {
            OnStopMove?.Invoke();
        }
        if (YandexGame.EnvironmentData.isDesktop)
        {
            input = new DesctopInput();
        }
        else
        {
            input = new MobileInput();
        }
    }

    private void Update()
    {
        if (input.IsStartClick())
        {
            startClickPosition = Input.mousePosition;
        }
        else if (input.IsClicking())
        {
            ratio = (Input.mousePosition.x - startClickPosition.x) / (Screen.width / (Speed));
            step = limit * ratio;
        }
        else
        {
            step = 0;
        }
        if (IsMoving == false)
        {
            step = 0;
            ratio = 0;
        }
        selfTransform.localPosition = new Vector3(Mathf.Clamp(selfTransform.localPosition.x + step, -limit, limit), selfTransform.localPosition.y, selfTransform.localPosition.z);
        startClickPosition = Input.mousePosition;
    }

}
