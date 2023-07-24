using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    [SerializeField] private List<Vector3> sizeOptions;

    private void Awake()
    {
        transform.localScale = sizeOptions[Random.Range(0, sizeOptions.Count)];
    }
}
