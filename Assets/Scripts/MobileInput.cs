using System.Linq;
using UnityEngine;

internal class MobileInput : IInput
{
    public bool IsClicking()
    {
        return Input.touches.Any(x => x.phase == TouchPhase.Moved || x.phase == TouchPhase.Stationary);
    }

    public bool IsEndClick()
    {
        return Input.touches.Any(x => x.phase == TouchPhase.Ended || x.phase == TouchPhase.Canceled);
    }

    public bool IsStartClick()
    {
        return Input.touches.Any(x => x.phase == TouchPhase.Began);
    }
}