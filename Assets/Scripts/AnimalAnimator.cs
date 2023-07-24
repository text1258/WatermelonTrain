using UnityEngine;
using UnityEngine.Events;
using static Clock;

public class AnimalAnimator : MonoBehaviour
{
    [SerializeField] private UnityEvent onMoving;
    private Transform selfTransform;

    private void Awake()
    {
        selfTransform = transform;
    }

    public void MoveTo(float duration, AnimationCurve additionalHeightCurve, Transform to, Transform startParrent, Transform endParrent)
    {
        Vector3 startPosition = selfTransform.position;
        StartCoroutine(Timer(duration,
            onStartTimer: () =>
            {
                onMoving?.Invoke();
                selfTransform.parent = startParrent;
            },
            onTick: (float filling) =>
            {
                selfTransform.position = Vector3.Lerp(startPosition, to.position, filling) + Vector3.up * additionalHeightCurve.Evaluate(filling);
            },
            onCloseTimer: () =>
            {
                selfTransform.position = to.position;
                selfTransform.parent = endParrent;
            }
            ));
    }

    public void RotateTo(float duration, Quaternion rotation)
    {
        Quaternion startRotation = selfTransform.rotation;
        StartCoroutine(Timer(duration,
            onTick: (float filling) =>
            {
                selfTransform.rotation = Quaternion.Lerp(startRotation, rotation, filling);
            },
            onCloseTimer: () =>
            {
                selfTransform.rotation = rotation;
            }
            ));
    }
}