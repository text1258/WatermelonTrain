using System;
using UnityEngine;
using YG;

public class Player : MonoBehaviour
{
    private long adedMoney;
    private int addedMoneyScaler = 1;
    public Action<long> OnMoneyChanged;

    public int Level
    {
        get => YandexGame.savesData.Level;
        set
        {
            if (value < YandexGame.savesData.Level)
            {
                return;
            }
            YandexGame.savesData.Level = value;
        }
    }

    public long AddedMoney
    {
        get => adedMoney * addedMoneyScaler;
        set
        {
            adedMoney = value;
            OnMoneyChanged?.Invoke(YandexGame.savesData.Money + value * AddedMoneyScaler);
        }
    }

    public int AddedMoneyScaler
    {
        get => addedMoneyScaler;
        set
        {
            if (value < 0)
            {
                return;
            }
            addedMoneyScaler = value;
            OnMoneyChanged?.Invoke(YandexGame.savesData.Money + AddedMoney);
        }
    }

    public MonkeySkin SelectSkin
    {
        set
        {
            YandexGame.savesData.SelectSkinId = value.Id;
            YandexGame.SaveProgress();
        }
    }

    private void Start()
    {
        YandexGame.LoadProgress();
    }

    public void AddSkin(MonkeySkin skin)
    {
        YandexGame.savesData.OpenSkinsIdes.Add(skin.Id);
        YandexGame.SaveProgress();
    }
}
