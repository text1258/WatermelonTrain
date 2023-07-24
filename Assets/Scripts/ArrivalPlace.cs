using UnityEngine;

public class ArrivalPlace : InteractiveObject
{
    [SerializeField] private Transform arrivalPoint;
    [SerializeField] private float movementDuration;
    [SerializeField] private AnimationCurve additionalMovementHeightCurve;

    public override void FirstLocomotiveIntersection(Locomotive locomotive)
    {
        if (locomotive.HasPassengers == false)
        {
            return;
        }
        locomotive.PassengerCars[locomotive.LastOccupiedTrainCar].Passenger.AnimalAnimator.MoveTo(movementDuration, additionalMovementHeightCurve, arrivalPoint, null, arrivalPoint);
        locomotive.PassengerCars[locomotive.LastOccupiedTrainCar].OnTrainCarArrival?.Invoke();
        locomotive.PassengerCars[locomotive.LastOccupiedTrainCar].Passenger.transform.LookAt(arrivalPoint.position);
        locomotive.PassengerCars[locomotive.LastOccupiedTrainCar].Passenger = null;
        locomotive.SellTicket();
    }
}
