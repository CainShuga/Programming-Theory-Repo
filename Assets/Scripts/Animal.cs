using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class Animal : MonoBehaviour, IPointerClickHandler
{
    // VARIABLES

    protected int animalValue = 1;
    protected int behaviorBonus = 2;

    protected float speed = 1.0f;
    public float behaviorDuration = 3.0f;
    public float movementDuration = 3.0f;

    protected float chanceOfMovement = 0.4f;
    protected float chanceOfBehavior = 0.3f;
    protected float rollToMove;
    protected float rollToBehave;
    public bool canRollToMove = true;
    public bool canRollToBehave = true;
    public bool movementTech = false;
    public bool doingBehavior = false;

    public bool picTaken = false;
    public bool beenPetted = false;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        InvokeRepeating("RandomBehaviorChance", 4f, 2f);
        InvokeRepeating("RandomMovementChance", 4.5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        if (movementTech)
        {
            UniqueMovement();
        }
        if (transform.position.x < -20) 
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) 
        {
            TakePicture();

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            PetAnimal();
        }
    }

    // CUSTOM METHODS BELOW

    public void MoveLeft()
    {
        if (!doingBehavior && !movementTech )
        {
            //Debug.Log("Moving left!");
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
    }

    public void TakePicture()
    {
        if (!picTaken)
        {
            picTaken = true;
            Debug.Log("You took a pic!");
            GameManager.Instance.UpdateScore(animalValue);

            if (doingBehavior)
            {
                GameManager.Instance.UpdateScore(behaviorBonus);
            }
        }
        else if (picTaken)
        {
            Debug.Log("You can only take one picture!");
        }
    }

    public virtual void PetAnimal()
    {
        if (!beenPetted)
        {
            Debug.Log("You have petted the beast.");
            beenPetted = true;
        }
        else if (beenPetted)
        {
            Debug.Log("You may only pet the beast once!");
        }
    }

    public virtual void PerformBehavior()
    {
        //Debug.Log("Starting behavior!");
        
        StartCoroutine(ResetBehavior());
    }

    public virtual void UniqueMovement()
    {
        //Debug.Log("This is a unique movement, which is different for each animal!");
        
        StartCoroutine(ResetMovement());
    }

    private void RandomBehaviorChance()
    {

        if (!doingBehavior && !movementTech && canRollToBehave)
        {
            rollToBehave = Random.value;
            if (rollToBehave < chanceOfBehavior)
            {
                Debug.Log($"Behavior randomly begun with {rollToBehave}!");
                canRollToBehave = false;
                //doingBehavior = true;
                PerformBehavior();
                
            }
        }
    }

    private void RandomMovementChance()
    {
        if (!movementTech && !doingBehavior && canRollToMove)
        {
            rollToMove = Random.value;
            if (rollToMove < chanceOfMovement)
            {
                Debug.Log($"Movement randomly begun with {rollToMove}!");
                canRollToMove = false;
                movementTech = true;
                //UniqueMovement();

            }
        }
    }    
        
    


    // COROUTINES

    public IEnumerator ResetBehavior()
    {
        yield return new WaitForSeconds(behaviorDuration);
        Debug.Log("Behavior reset!");
        doingBehavior = false;
        StartCoroutine(ResetRollToBehave());
    }

    public IEnumerator ResetMovement()
    {  yield return new WaitForSeconds(movementDuration);
        Debug.Log("Movement reset!");
        movementTech = false;
        StartCoroutine(ResetRollToMove());
    }

    public IEnumerator ResetRollToMove()
    {
        yield return new WaitForSeconds(7);
        canRollToMove = true;
    }

    public IEnumerator ResetRollToBehave()
    {
        yield return new WaitForSeconds(7);
        canRollToBehave = true;
    }


}
