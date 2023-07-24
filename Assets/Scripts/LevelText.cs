using UnityEngine;
using TMPro;
using YG;

public class LevelText : MonoBehaviour, IDataText
{
    [SerializeField] private TMP_Text lable;

    private void Reset()
    {
        lable = GetComponent<TMP_Text>();
    }

    private void Awake()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        lable.text = $"{YandexGame.savesData.Level}";
    }
}
