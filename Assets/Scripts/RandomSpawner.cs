using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnObjects;

    public void Awake()
    {
        Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], parent: transform);
    }
}
