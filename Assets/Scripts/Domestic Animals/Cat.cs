using UnityEngine;

public class Cat : DomesticAnimal // INHERITANCE
{

    // OVERRIDES (POLYMORPHISM)

    public override void UniqueMovement()
    {
        Debug.Log("Cats like to lie down and sleep!");
        StartCoroutine(ResetMovement());
    }

    public override void PerformBehavior()
    {
        Debug.Log("Oh he's so bathin'");
        doingBehavior = true;
        StartCoroutine(ResetBehavior());
    }
}
