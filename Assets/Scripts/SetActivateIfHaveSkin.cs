using System.Collections.Generic;
using UnityEngine;
using YG;

public class SetActivateIfHaveSkin : MonoBehaviour
{
    [SerializeField] private List<SetActivateSkinData> setActivateSkinData;

    private void Start()
    {
        SetActivateObjects();
    }

    public void SetActivateObjects()
    {
        foreach (SetActivateSkinData data in setActivateSkinData)
        {
            if (YandexGame.savesData.OpenSkinsIdes.Contains(data.Skin.Id))
            {
                data.ObjectToSetActive.SetActive(data.SetActive);
            }
            else
            {
                data.ObjectToSetActive.SetActive(!data.SetActive);
            }
        }
    }
}
