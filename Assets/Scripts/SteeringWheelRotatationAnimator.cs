using UnityEngine;

public class SteeringWheelRotatationAnimator : MonoBehaviour
{
    [SerializeField] private HorizontalSwipeMovement horizontalMovemer;
    [SerializeField] private Animator steeringWheelAnimator;

    private void OnEnable()
    {
        horizontalMovemer.OnStartMove += StartAnimation;
        horizontalMovemer.OnStopMove += StopAnimation;
    }

    private void OnDisable()
    {
        horizontalMovemer.OnStartMove -= StartAnimation;
        horizontalMovemer.OnStopMove -= StopAnimation;
    }
    
    private void StartAnimation()
    {
        steeringWheelAnimator.speed = 1;
    }

    private void StopAnimation()
    {
        steeringWheelAnimator.speed = 0;
    }
}

