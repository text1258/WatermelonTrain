using System;
using UnityEngine;

public class ForwardTransformMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isMoving = false;
    public Action<float> OnChaneSpeed;
    public Action OnStartMove;
    public Action OnStopMove;
    private Transform selfTransform;

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

    public float Speed
    {
        get => speed;
        set
        {
            if (value < 0)
            {
                return;
            }
            speed = value;
            if (IsMoving)
            {
                OnChaneSpeed?.Invoke(value);
            }
        }
    }

    private void Awake()
    {
        selfTransform = transform;
    }

    private void Start()
    {
        if (IsMoving == false)
        {
            OnStopMove?.Invoke();
        }
    }

    private void Update()
    {
        if (IsMoving == false)
        {
            return;
        }
        selfTransform.position += Vector3.forward * speed * Time.deltaTime;
    }
}