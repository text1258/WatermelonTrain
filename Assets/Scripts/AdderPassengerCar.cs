public class AdderPassengerCar : InteractiveObject
{
    public override void FirstLocomotiveIntersection(Locomotive locomotive)
    {
        if (locomotive.UnlockedPassengersCarsCount < locomotive.PassengerCars.Count)
        {
            locomotive.PassengerCars[locomotive.UnlockedPassengersCarsCount].gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
        locomotive.OnPassangerCarsChange?.Invoke(locomotive.UnlockedPassengersCarsCount);
    }
}
