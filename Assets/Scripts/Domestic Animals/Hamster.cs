using UnityEngine;

public class Hamster : DomesticAnimal // INHERITANCE
{ 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed *= 2;
        animalValue = 3;
        chanceOfMovement = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        // Hamsters don't have a unique movement, instead having a slightly higher speed. UniqueMovement will never be called on Hamsters.
    }

    // OVERRIDES (POLYMORPHISM)

    public override void PerformBehavior()
    {
        Debug.Log("Oh that boy squeakin'");
        doingBehavior = true;
        StartCoroutine(ResetBehavior());
    }
}
