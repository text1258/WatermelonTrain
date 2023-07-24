using System.Collections.Generic;
using UnityEngine;
using YG;

public class SetActivateIfSelectSkin : MonoBehaviour
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
            if (data.Skin.Id == YandexGame.savesData.SelectSkinId)
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
