using UnityEngine;

public class Animal : MonoBehaviour 
{
    [SerializeField] private AnimalAnimator animalAnimator;

    public AnimalAnimator AnimalAnimator => animalAnimator;
}