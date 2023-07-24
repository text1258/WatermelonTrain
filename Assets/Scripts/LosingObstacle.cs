using UnityEngine;

public class LosingObstacle : InteractiveObject
{
    [SerializeField] private LoseScreen loseScreen;

    public override void FirstLocomotiveIntersection(Locomotive locomotive)
    {
        loseScreen.Show();
        locomotive.HorizontalMovemer.IsMoving = false;
        locomotive.ForwardMover.IsMoving = false;
        LevelManagement.Pause(() => gameObject.SetActive(false));
    }
}
