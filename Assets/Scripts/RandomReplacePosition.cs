using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomReplacePosition : MonoBehaviour
{
    [SerializeField] private List<Transform> replaceble;

    public void Awake()
    {
        List<Vector3> positions = replaceble.Select(x => x.position).ToList();
        for (int i = 0; i < replaceble.Count; i++)
        {
            int positionIndex = Random.Range(0, positions.Count);
            replaceble[i].position = positions[positionIndex];
            positions.RemoveAt(positionIndex);
        }
    }
}