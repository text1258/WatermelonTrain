using UnityEngine;
using static Clock;

public class FinishScreenBlindsAppearAnimation : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private RectTransform top;
    [SerializeField] private RectTransform bottom;
    [SerializeField] private bool reverse;

    private void OnEnable()
    {
        float blindsFilling = 1f;
        StartCoroutine(Timer(duration, 
            onTick: (float filling) =>
            {
                if (reverse == true)
                {
                    blindsFilling = 1 - filling;
                }
                else
                {
                    blindsFilling = filling;
                }
                top.anchorMin = new Vector2(top.anchorMin.x, blindsFilling);
                bottom.anchorMax = new Vector2 (bottom.anchorMax.x, 1 - blindsFilling);
            },
            onCloseTimer: () =>
            {
                if (reverse == false)
                {
                    top.anchorMin = new Vector2(top.anchorMin.x, 1);
                    bottom.anchorMax = new Vector2(bottom.anchorMax.x, 0);
                }
                else
                {
                    top.anchorMin = new Vector2(top.anchorMin.x, 0);
                    bottom.anchorMax = new Vector2(bottom.anchorMax.x, 1);
                }
            }
            ));
    }
}
