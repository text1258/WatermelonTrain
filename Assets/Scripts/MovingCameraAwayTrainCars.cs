using UnityEngine;
using static Clock;

public class MovingCameraDistancingTrainCars : MonoBehaviour
{
    [SerializeField] private SmoothFollowAt cameraFollower;
    [SerializeField] private Locomotive locomotive;
    [SerializeField] private int criticalTrainCarsCount;
    [SerializeField] private int maxDistancingTrainCarsCount;
    [SerializeField] private float addingDistance;
    [SerializeField] private float offsetingTime;
    private float previousTrainCarsCount;

    private void Awake()
    {
        previousTrainCarsCount = locomotive.UnlockedPassengersCarsCount;
    }

    private void OnEnable()
    {
        locomotive.OnPassangerCarsChange += CameraDistancing;
    }

    private void OnDisable()
    {
        locomotive.OnPassangerCarsChange -= CameraDistancing;
    }

    private void CameraDistancing(int passangerCarsCount)
    {
        if (criticalTrainCarsCount > passangerCarsCount | passangerCarsCount > maxDistancingTrainCarsCount)
        {
            return;
        }
        float addingDistance = this.addingDistance;
        if (previousTrainCarsCount > passangerCarsCount)
        {
            addingDistance *= -1;
        }
        previousTrainCarsCount = passangerCarsCount;
        Vector3 startCameraOffset = cameraFollower.Offset;
        StartCoroutine(Timer(offsetingTime, 
            onTick: (float filling) =>
            {
                cameraFollower.Offset = Vector3.Lerp(startCameraOffset, startCameraOffset + Vector3.forward * addingDistance, filling);
            }
            ));
    }
}
