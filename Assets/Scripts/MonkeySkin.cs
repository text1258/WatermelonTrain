using UnityEngine;

[CreateAssetMenu(fileName = "MonkeySkin", menuName = "ScriptableObjects/MonkeySkin", order = 1)]
public class MonkeySkin : ScriptableObject
{
    [SerializeField] private int id;

    public int Id { get => id; set => id = value; }
}