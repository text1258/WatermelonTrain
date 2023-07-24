using UnityEngine;
using YG;
using static LevelManagement;

public class GameLoader : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += LoadPlayerLevel;

    private void OnDisable() => YandexGame.GetDataEvent -= LoadPlayerLevel;

    private void LoadPlayerLevel()
    {
        LoadLevel(YandexGame.savesData.Level);
    }
}
