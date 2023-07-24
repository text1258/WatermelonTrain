using UnityEngine;

public class AdderPassenger : InteractiveObject
{
    [SerializeField] private Animal passenger;
    [SerializeField] private float passengerSeatDuration;
    [SerializeField] private AnimationCurve additionalHeightCurve;

    public override void FirstLocomotiveIntersection(Locomotive locomotive)
    {
        if (locomotive.NearestFreeTrainCar >= locomotive.UnlockedPassengersCarsCount)
        {
            return;
        }
        locomotive.StopMoving(passengerSeatDuration);
        passenger.AnimalAnimator.MoveTo(passengerSeatDuration, additionalHeightCurve, locomotive.PassengerCars[locomotive.NearestFreeTrainCar].PassengerSeat, 
            null, locomotive.PassengerCars[locomotive.NearestFreeTrainCar].PassengerSeat);
        passenger.AnimalAnimator.RotateTo(passengerSeatDuration, Quaternion.Euler(Vector3.zero));
        locomotive.PassengerCars[locomotive.NearestFreeTrainCar].Passenger = passenger;
    }
}