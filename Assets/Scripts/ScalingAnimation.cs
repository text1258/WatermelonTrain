using UnityEngine;
using NaughtyAttributes;
using static Clock;
using UnityEngine.Events;

public class ScalingAnimation : MonoBehaviour
{
    [SerializeField] private bool startOnEnable;
    [SerializeField] private AnimationCurve sizeMultiplier;
    [SerializeField, ShowIf("startOnEnable")] private float onEnableAnimationDuraction;
    [SerializeField] private UnityEvent afterUpscaling;
    private Transform selfTransform;

    public UnityEvent AfterUpscaling { get => afterUpscaling; set => afterUpscaling = value; }

    private void Awake()
    {
        selfTransform = transform;
    }

    private void OnEnable()
    {
        if (startOnEnable)
        {
            ScaleAnimation(onEnableAnimationDuraction);
        }
    }

    public void ScaleAnimation(float duration)
    {
        Vector3 startScale = selfTransform.localScale;
        StartCoroutine(Timer(duration,
            onStartTimer: () =>
            {
                startScale = selfTransform.localScale;
            },
            onTick: (float filling) =>
            {
                selfTransform.localScale = startScale * sizeMultiplier.Evaluate(filling);
            },
            onCloseTimer: () =>
            {
                selfTransform.localScale = startScale;
                AfterUpscaling?.Invoke();
            }
            ));
    }

    public void ScaleAnimation()
    {
        Vector3 startScale = selfTransform.localScale;
        StartCoroutine(Timer(onEnableAnimationDuraction,
            onStartTimer: () =>
            {
                startScale = selfTransform.localScale;
            },
            onTick: (float filling) =>
            {
                selfTransform.localScale = startScale * sizeMultiplier.Evaluate(filling);
            },
            onCloseTimer: () =>
            {
                selfTransform.localScale = startScale;
                AfterUpscaling?.Invoke();
            }
            ));
    }
}
