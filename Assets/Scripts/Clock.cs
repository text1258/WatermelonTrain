using System;
using System.Collections;
using UnityEngine;

public static class Clock
{
    public static IEnumerator Timer(float duration, Action<float> onTick, Action onStartTimer = null, Action onCloseTimer = null)
    {
        onStartTimer?.Invoke();
        float pastTime = 0f;
        while (duration > pastTime)
        {
            pastTime += Time.deltaTime;
            onTick?.Invoke(pastTime / duration);
            yield return null;
        }
        onCloseTimer?.Invoke();
        yield break;
    }

    public static IEnumerator Timer(float duration, Action onCloseTimer, Action onStartTimer = null)
    {
        onStartTimer?.Invoke();
        yield return new WaitForSeconds(duration);
        onCloseTimer?.Invoke();
        yield break;
    }
}