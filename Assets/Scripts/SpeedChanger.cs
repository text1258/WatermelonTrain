using UnityEngine;
using static Clock;

public class SpeedChanger : InteractiveObject
{
    [SerializeField] private float addingDuration;
    [SerializeField] private float addForwardSpeed;
    [SerializeField] private float addHorizontalSpeed;

    public override void LocomotiveIntersection(Locomotive locomotive)
    {
        StartCoroutine(Timer(addingDuration, 
            onStartTimer: () =>
            {
                locomotive.ForwardMover.Speed += addForwardSpeed;
                locomotive.HorizontalMovemer.Speed += addHorizontalSpeed;
            }, 
            onCloseTimer: () =>
            {
                locomotive.ForwardMover.Speed -= addForwardSpeed;
                locomotive.HorizontalMovemer.Speed -= addHorizontalSpeed;
            }
            ));
    }
}

