using UnityEngine;

public class Wolf : WildAnimal
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 1.5f;
        biteCost += 1;
        chanceOfMovement = 0f;
}
        void Update()
    {
        MoveLeft();
        // Wolves don't have a unique movement, instead having a slightly higher speed. UniqueMovement will never be called on wolves.
        if (doingBehavior)
        {
            behaviorIndicator.gameObject.SetActive(true);
        }
    }

    // OVERRIDES

    public override void PerformBehavior()
    {
        Debug.Log("Oh that boy howling");
        doingBehavior = true;
        StartCoroutine(ResetBehavior());
    }
}
