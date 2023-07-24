using UnityEngine;
using UnityEngine.Events;

public class PassengerCar : MonoBehaviour
{
    [SerializeField] private Transform passengerSeat;
    [SerializeField] private WheelsAnimator wheelsAnimator;
    [SerializeField] private UnityEvent onTrainCarArrival;
    private Animal passenger;

    public Animal Passenger { get => passenger; set => passenger = value; }
    public Transform PassengerSeat { get => passengerSeat; set => passengerSeat = value; }
    public Locomotive Locomotive
    {
        set
        {
            wheelsAnimator.PathFollower = value.ForwardMover;
        }
    }

    public UnityEvent OnTrainCarArrival { get => onTrainCarArrival; set => onTrainCarArrival = value; }

    private void OnTriggerEnter(Collider other) => other.GetComponent<IInteractive>()?.Interaction(this);

    private void OnCollisionEnter(Collision collision) => collision.gameObject.GetComponent<IInteractive>()?.Interaction(this);
}
