using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LevelManagement : MonoBehaviour
{
    public static int CurrentLevel => SceneManager.GetActiveScene().buildIndex;

    public static void Restart()
    {
        LoadLevel(CurrentLevel);
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
    }

    public static void Pause(Action onPause)
    {
        onPause?.Invoke();
        Time.timeScale = 0f;
    }

    public static void Play()
    {
        Time.timeScale = 1f;
    }

    public static void LoadLevel(int index)
    {
        if (index < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadSceneAsync(index);
            return;
        }
        SceneManager.LoadSceneAsync(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void NextLevel(Player player)
    {
        player.Level += 1;
        YandexGame.savesData.Money += player.AddedMoney;
        YandexGame.NewLeaderboardScores("bestLevel", player.Level);
        YandexGame.SaveProgress();
        LoadLevel(player.Level);
    }
}