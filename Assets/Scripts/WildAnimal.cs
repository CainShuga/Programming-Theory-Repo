using UnityEngine;

public class WildAnimal : Animal // INHERITANCE
{
    public int biteCost = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animalValue += 1;
    }

    public override void PetAnimal() // POLYMORPHISM
    {
        if (!beenPetted)
        {
            Debug.Log("The beast has bitten you!");
            beenPetted = true;
            GameManager.Instance.UpdateScore(-biteCost);
        }
        else if (beenPetted)
        {
            Debug.Log("You really want to do that again?");
        }
    }
}
