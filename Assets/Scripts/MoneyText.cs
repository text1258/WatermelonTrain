using UnityEngine;
using TMPro;
using YG;

public class MoneyText : MonoBehaviour, IDataText
{
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text label;
    [SerializeField] private ScalingAnimation upscaleAnimation;
    [SerializeField] private float upscaleAnimationDuraction;

    private void OnEnable()
    {
        player.OnMoneyChanged += UpdateText;
        YandexGame.GetDataEvent += UpdateText;
    }

    private void OnDisable()
    {
        player.OnMoneyChanged -= UpdateText;
        YandexGame.GetDataEvent -= UpdateText;
    }

    public void UpdateText()
    {
        UpdateText(YandexGame.savesData.Money + player.AddedMoney);
    }

    public void UpdateText(long value)
    {
        label.text = FormatNumber(value);
        upscaleAnimation.ScaleAnimation(upscaleAnimationDuraction);
    }

    public static string FormatNumber(double number)
    {
        if (number >= 100000000)
        {
            return (number / 1000000D).ToString("0.#M");
        }
        if (number >= 1000000)
        {
            return (number / 1000000D).ToString("0.##M");
        }
        if (number >= 100000)
        {
            return (number / 1000D).ToString("0.#k");
        }
        if (number >= 10000)
        {
            return (number / 1000D).ToString("0.##k");
        }

        return number.ToString("#,0");
    }
}