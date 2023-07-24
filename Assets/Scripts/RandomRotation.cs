using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    [SerializeField] private List<Vector3> rotationOptions;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(rotationOptions[Random.Range(0, rotationOptions.Count)]);
    }
}
