using UnityEngine;

internal class DesctopInput : IInput
{
    public bool IsClicking()
    {
        return Input.GetMouseButton(0);
    }

    public bool IsEndClick()
    {
        return Input.GetMouseButtonUp(0);
    }

    public bool IsStartClick()
    {
        return Input.GetMouseButtonDown(0);
    }
}