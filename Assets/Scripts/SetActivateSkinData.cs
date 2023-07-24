using System;
using UnityEngine;

[Serializable]
public struct SetActivateSkinData
{
    public MonkeySkin Skin;
    public bool SetActive;
    public GameObject ObjectToSetActive;
}