using UnityEngine;
using UnityEngine.Events;
using YG;

public class RewardAdsShower : MonoBehaviour
{
    [SerializeField] private UnityEvent onReward;
    [SerializeField] private UnityEvent onError;
    [SerializeField] private UnityEvent onOpen;
    [SerializeField] private UnityEvent onClose;

    private void Awake()
    {
        onError.AddListener(UnsubscribeAll);
        onReward.AddListener(UnsubscribeAll);
    }

    public void ShowRevardAds()
    {
        YandexGame.RewardVideoEvent += OnVideoReward;
        YandexGame.ErrorVideoEvent += OnErrorVideo;
        YandexGame.OpenVideoEvent += OnOpenVideo;
        YandexGame.CloseVideoEvent += OnCloseVideo;
        YandexGame.RewVideoShow(0);
    }

    private void OnVideoReward(int id) => onReward.Invoke();

    private void OnErrorVideo()
    {
        onError.Invoke();
    }

    private void OnOpenVideo() => onOpen.Invoke();

    private void OnCloseVideo() => onClose.Invoke();

    private void UnsubscribeAll()
    {
        YandexGame.RewardVideoEvent -= OnVideoReward;
        YandexGame.ErrorVideoEvent -= OnErrorVideo;
        YandexGame.OpenVideoEvent -= OnOpenVideo;
        YandexGame.CloseVideoEvent -= OnCloseVideo;
    }
}