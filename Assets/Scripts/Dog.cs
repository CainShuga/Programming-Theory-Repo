using UnityEngine;

public class Dog : DomesticAnimal
{

    void Start()
    {
        animalValue = 2;
    }
    // OVERRIDES

    public override void UniqueMovement()
    {
        Debug.Log("Dogs turn around and run the other way for a bit!");
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        StartCoroutine(ResetMovement());
    }

    public override void PerformBehavior()
    {
        Debug.Log("Oh he's so barkin");
        doingBehavior = true;
        StartCoroutine(ResetBehavior());
    }
}
