public class PassengerCarReductor : InteractiveObject
{
    public override void FirstLocomotiveIntersection(Locomotive locomotive)
    {
        if (locomotive.UnlockedPassengersCarsCount == 0)
        {
            return;
        }
        if (locomotive.PassengerCars[locomotive.UnlockedPassengersCarsCount - 1].Passenger != null)
        {
            locomotive.RemovePassenger(locomotive.UnlockedPassengersCarsCount - 1).gameObject.SetActive(false);
        }
        locomotive.PassengerCars[locomotive.UnlockedPassengersCarsCount - 1].gameObject.SetActive(false);
        gameObject.SetActive(false);
        locomotive.OnPassangerCarsChange?.Invoke(locomotive.UnlockedPassengersCarsCount);
    }
}