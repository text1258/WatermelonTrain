using UnityEngine;

public class PassengerReductor : InteractiveObject
{
    [SerializeField] private float stopDutaction;
    [SerializeField] private Transform cageArrivalPoint;

    public override void FirstLocomotiveIntersection(Locomotive locomotive)
    {
        if (locomotive.HasPassengers == false)
        {
            gameObject.SetActive(false);
            return;
        }
        locomotive.StopMoving(stopDutaction);
        Animal removingPassanger = locomotive.RemovePassenger(locomotive.LastOccupiedTrainCar);
        removingPassanger.transform.position = cageArrivalPoint.position;
        removingPassanger.transform.LookAt(locomotive.transform);
        removingPassanger.transform.SetParent(cageArrivalPoint);
    }
}