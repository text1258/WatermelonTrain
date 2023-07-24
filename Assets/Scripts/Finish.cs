using UnityEngine;

public class Finish : InteractiveObject
{
    [SerializeField] private FinishScreen finishScreen;

    public override void FirstLocomotiveIntersection(Locomotive locomotive)
    {
        locomotive.StopMoving();
        finishScreen.Show();
    }
}
