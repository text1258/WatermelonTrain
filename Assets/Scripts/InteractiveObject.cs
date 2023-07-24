using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField] protected UnityEvent onFirstLocomotiveIntersection;
    [SerializeField] protected UnityEvent onLocomotiveIntersection;
    [SerializeField] protected UnityEvent onPassangerCarIntersection;
    private bool wasLocomotiveInteraction = false;

    public void Interaction(Locomotive locomotive)
    {
        if (locomotive == null)
        {
            return;
        }
        onLocomotiveIntersection?.Invoke();
        LocomotiveIntersection(locomotive);
        if (wasLocomotiveInteraction == false)
        {
            onFirstLocomotiveIntersection?.Invoke();
            FirstLocomotiveIntersection(locomotive);
            wasLocomotiveInteraction = true;
        }
    }

    public void Interaction(PassengerCar passengerCar)
    {
        if (passengerCar == null)
        {
            return;
        }
        onPassangerCarIntersection?.Invoke();
        PassangerCarIntersection(passengerCar);
    }

    public virtual void FirstLocomotiveIntersection(Locomotive locomotive) { }

    public virtual void LocomotiveIntersection(Locomotive locomotive) { }

    public virtual void PassangerCarIntersection(PassengerCar passengerCar) { }
}
