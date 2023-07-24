using UnityEngine;

public class WheelsAnimator : MonoBehaviour
{
    [SerializeField] private ForwardTransformMovement forwardMovement;
    [SerializeField] private Animator wheelsAnimator;

    public ForwardTransformMovement PathFollower { get => forwardMovement; set => forwardMovement = value; }

    private void OnEnable()
    {
        PathFollower.OnChaneSpeed += ChangeAnimationSpeed;
        PathFollower.OnStartMove += StartAnimation;
        PathFollower.OnStopMove += StopAnimation;
    }

    private void OnDisable()
    {
        PathFollower.OnChaneSpeed -= ChangeAnimationSpeed;
        PathFollower.OnStartMove -= StartAnimation;
        PathFollower.OnStopMove -= StopAnimation;
    }

    private void StopAnimation()
    {
        ChangeAnimationSpeed(0);
    }

    private void StartAnimation()
    {
        ChangeAnimationSpeed(PathFollower.Speed);
    }

    private void ChangeAnimationSpeed(float speed)
    {
        wheelsAnimator.speed = speed;
    }
}
