using UnityEngine;
using UnityEngine.EventSystems;

public class DomesticAnimal : Animal
{
    public int pettingBonus = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    

    public override void PetAnimal()
    {
        if (!beenPetted)
        {
            Debug.Log("You have petted the beast.");
            beenPetted = true;
            GameManager.Instance.UpdateScore(pettingBonus);
        }
        else if (beenPetted)
        {
            Debug.Log("You may only pet the beast once!");
        }
    }
}
