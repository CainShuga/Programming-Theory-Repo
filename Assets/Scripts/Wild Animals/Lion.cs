using UnityEngine;

public class Lion : WildAnimal
{
    void Start()
    {
        animalValue = 2;
        biteCost += 2;
    }
    // OVERRIDES

    public override void UniqueMovement()
    {
        Debug.Log("Lions leap forward!");
        // This will probably involve some messing with Rigidbody and require me to change how movement works overall so I'm not going to mess with it right now.
        StartCoroutine(ResetMovement());
    }

    public override void PerformBehavior()
    {
        Debug.Log("Oh he's so roarin");
        doingBehavior = true;
        StartCoroutine(ResetBehavior());
    }
}
