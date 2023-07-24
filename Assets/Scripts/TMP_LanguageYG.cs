using TMPro;
using UnityEngine;
using YG;

[RequireComponent(typeof(LanguageYG), typeof(TMP_Text))]
public class TMP_LanguageYG : MonoBehaviour
{
    [SerializeField] private LanguageYG languageYG;
    [SerializeField] private TMP_Text text;

    private void Reset()
    {
        languageYG = GetComponent<LanguageYG>();
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        YandexGame.SwitchLangEvent += SwitchLanguage;
        SwitchLanguage(YandexGame.savesData.language);
    }

    private void OnDisable() => YandexGame.SwitchLangEvent -= SwitchLanguage;

    public void SwitchLanguage(string lang)
    {
        for (int i = 0; i < languageYG.languages.Length; i++)
        {
            if (lang == languageYG.infoYG.LangName(i))
            {
                AssignTranslate(languageYG.languages[i]);
            }
        }
    }

    private void AssignTranslate(string translation)
    {
        text.text = translation;
    }
}
