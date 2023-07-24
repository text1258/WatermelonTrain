using UnityEngine;
using UnityEngine.Events;
using YG;

public class Salling : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private UnityEvent onSelling;
    [SerializeField] private UnityEvent onUnsuccessfulSelling;

    public void Sell()
    {
        if (cost > YandexGame.savesData.Money)
        {
            onUnsuccessfulSelling?.Invoke();
            return;
        }
        YandexGame.savesData.Money -= cost;
        YandexGame.SaveProgress();
        onSelling?.Invoke();
    }
}