using System.Collections.Generic;
using UnityEngine;

public class TrainCarsFollowLocomotive : MonoBehaviour
{
    [SerializeField] private Transform locomotive;
    [SerializeField] private List<Transform> paccangerCars;
    [SerializeField] private float spacing;
    [SerializeField] private float smoothSpeed;

    public List<Transform> PaccangerCars => paccangerCars;

    public float Spacing { get => spacing; set => spacing = value; }

    private void LateUpdate()
    {
        locomotive.localPosition = Vector3.up * locomotive.localPosition.y;
        for (int i = 0; i < PaccangerCars.Count; i++)
        {
            if (i == 0)
            {
                PaccangerCars[i].position = new Vector3(Mathf.Lerp(PaccangerCars[i].position.x, locomotive.position.x, Time.smoothDeltaTime * smoothSpeed), PaccangerCars[i].position.y,
                    locomotive.position.z + (Spacing * (i + 1) * Mathf.Cos(PaccangerCars[i].rotation.eulerAngles.x * Mathf.Deg2Rad)));
                PaccangerCars[i].LookAt(locomotive);
                continue;
            }
            PaccangerCars[i].position = new Vector3(Mathf.Lerp(PaccangerCars[i].position.x, PaccangerCars[i - 1].position.x, Time.smoothDeltaTime * smoothSpeed), PaccangerCars[i].position.y, 
                locomotive.position.z + (Spacing * (i + 1) * Mathf.Cos(PaccangerCars[i].rotation.eulerAngles.x * Mathf.Deg2Rad)));
            PaccangerCars[i].LookAt(PaccangerCars[i - 1]);
        }
    }
}
