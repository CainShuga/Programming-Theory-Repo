using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class Animal : MonoBehaviour, IPointerClickHandler
{
    // VARIABLES

    protected int animalValue = 1;
    protected int behaviorBonus = 2;

    protected float speed = 2.0f;
    protected float behaviorDuration = 3.0f;
    protected float movementDuration = 3.0f;

    public float chanceOfMovement = 0.4f;
    public float chanceOfBehavior = 0.3f;
    protected float rollToMove;
    protected float rollToBehave;
    protected bool canRollToMove = true;
    protected bool canRollToBehave = true;
    protected bool movementTech = false;
    protected bool doingBehavior = false;

    protected bool picTaken = false;
    protected bool beenPetted = false;

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
        
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) 
        {
            TakePicture(); // ABSTRACTION

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            PetAnimal(); // ABSTRACTION
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
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public void TakePicture()
    {
        if (!picTaken)
        {
            picTaken = true;
            Debug.Log("You took a pic!");
            GameManager.Instance.UpdateScore(animalValue);
            chanceOfMovement /= 3;
            chanceOfBehavior /= 3;
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
        StartCoroutine(ResetBehavior());
    }

    public virtual void UniqueMovement()
    {           
       StartCoroutine(ResetMovement());
    }

    private void RandomBehaviorChance()
    {

        if (!doingBehavior && !movementTech && canRollToBehave)
        {
            rollToBehave = Random.value;
            if (rollToBehave < chanceOfBehavior)
            {
                
                canRollToBehave = false;
                
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
                
                canRollToMove = false;
                movementTech = true;
                
            }
        }
    }    
        
    


    // COROUTINES

    public IEnumerator ResetBehavior()
    {
        yield return new WaitForSeconds(behaviorDuration);
        //Debug.Log("Behavior reset!");
        doingBehavior = false;
        StartCoroutine(ResetRollToBehave());
    }

    public IEnumerator ResetMovement()
    {  yield return new WaitForSeconds(movementDuration);
        //Debug.Log("Movement reset!");
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
