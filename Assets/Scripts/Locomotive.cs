using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Clock;

public class Locomotive : MonoBehaviour
{
    [SerializeField] private PassengerCar passengerCarPrefab;
    [SerializeField] private List<PassengerCar> passengerCars;
    [SerializeField] private ForwardTransformMovement forwardMover;
    [SerializeField] private HorizontalSwipeMovement horizontalMovemer;
    [SerializeField] private TrainCarsFollowLocomotive trainCarsFollowLocomotive;
    [SerializeField] private Player player;
    [SerializeField] private int fare;
    public Action<int> OnPassangerCarsChange;

    public int UnlockedPassengersCarsCount => PassengerCars.Where(x => x.gameObject.activeSelf).Count();
    public int NearestFreeTrainCar => PassengerCars.IndexOf(PassengerCars.First(x => x.Passenger == null));
    public int LastOccupiedTrainCar => PassengerCars.IndexOf(PassengerCars.Last(x => x.Passenger != null));
    public List<PassengerCar> PassengerCars { get => passengerCars; set => passengerCars = value; }
    public ForwardTransformMovement ForwardMover { get => forwardMover; set => forwardMover = value; }
    public HorizontalSwipeMovement HorizontalMovemer { get => horizontalMovemer; set => horizontalMovemer = value; }
    public bool HasPassengers => passengerCars.Any(x => x.Passenger != null);

    private void OnValidate()
    {
        if (fare < 0)
        {
            fare = 0;
        }
    }

    public void Start()
    {
        CreatePassengerCars();
    }

    private void OnTriggerEnter(Collider other) => other.GetComponent<IInteractive>()?.Interaction(this);

    private void OnCollisionEnter(Collision collision) => collision.gameObject.GetComponent<IInteractive>()?.Interaction(this);

    private void CreatePassengerCars()
    {
        for (int i = 1; i <= FindObjectsByType<AdderPassengerCar>(FindObjectsSortMode.None).Length; i++)
        {
            PassengerCar currentPassengerCar = Instantiate(passengerCarPrefab);
            currentPassengerCar.Locomotive = this;
            trainCarsFollowLocomotive.PaccangerCars.Add(currentPassengerCar.transform);
            currentPassengerCar.gameObject.SetActive(false);
            PassengerCars.Add(currentPassengerCar);
        }
    }

    public void StopMoving(float duration)
    {
        StartCoroutine(Timer(duration,
            onStartTimer: () =>
            {
                StopMoving();
            },
            onCloseTimer: () =>
            {
                ContinueMoving();
            }
            ));
    }

    public void StopMoving()
    {
        ForwardMover.IsMoving = false;
        HorizontalMovemer.IsMoving = false;
    }

    public void ContinueMoving()
    {
        ForwardMover.IsMoving = true;
        HorizontalMovemer.IsMoving = true;
    }

    public Animal RemovePassenger(int passengerIndex)
    {
        if (passengerIndex < 0 | passengerIndex > LastOccupiedTrainCar)
        {
            throw new Exception("Unreal index of passenger");
        }
        Animal removingPassanger = PassengerCars[passengerIndex].Passenger;
        PassengerCars[passengerIndex].Passenger.transform.SetParent(null);
        PassengerCars[passengerIndex].Passenger = null;
        return removingPassanger;
    }

    public void SellTicket()
    {
        player.AddedMoney += fare;
    }
}
