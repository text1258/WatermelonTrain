using System.Collections.Generic;
using UnityEngine;

public class RandomActivator : MonoBehaviour
{
    [SerializeField] private List<GameObject> activationObjects;

    public void Awake()
    {
        activationObjects[Random.Range(0, activationObjects.Count)].SetActive(true);
    }
}
