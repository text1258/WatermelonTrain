using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    [SerializeField] protected GameObject panel;

    public void Show()
    {
        panel.SetActive(true);
    }
}