using UnityEngine;

public class Squirrel : WildAnimal
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 1.5f;
        animalValue = 3;
        movementDuration = 2.0f;
        chanceOfMovement = 0.4f;
        chanceOfBehavior = 0.3f;
    }

    // OVERRIDES

    public override void UniqueMovement()
    {
        Debug.Log("Squirrels skitter quickly across the screen!");
        transform.Translate(Vector3.left * Time.deltaTime * (3*speed), Space.World);
        StartCoroutine(ResetMovement());
    }

    public override void PerformBehavior()
    {
        Debug.Log("Oh he's so chatterin");
        doingBehavior = true;
        StartCoroutine(ResetBehavior());
    }
}
