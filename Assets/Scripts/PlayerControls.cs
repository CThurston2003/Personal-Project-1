/// Author: Caleb Thurston (CAT)
/// Description: Player Movement code for a personal project in Unity
/// Script Language: C#
/// Date Created: Sometime around end of February 2024 (Don't remember exact day)
//-----------------------------Dependencies--------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Adding the possibility for more complicated reads from the input system

public class PlayerControls : MonoBehaviour
{

//--------------------------Public variables to be editable in Unity-----------------------------------------

    //Variables related to the dodging mechanic
    public float dodgeVal = 5;  //Value by which the player moves when dodging
    public float dodgeTimer = 5f; //Making a dodge increment timer (later converted to milliseconds)
    public Animator animator; //Creating a reference to the player animator
    public Rigidbody2D rigidBody; //Creating a reference to the players rigidbody
    private PersonalProject1 personalProject1; //Creating a reference to the players inputs
    [SerializeField] private float moveSpeed; //Creating a reference to player moveSpeed
    Vector2 playerMovement; //Vector 2 Variable to store the movement of the player to later be assigned in update
    public SpriteRenderer spriteRenderer; //referencing the character sprite renderer component

//-------------------Start method--------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        
    }

//--------------------Move Method------------------------------------

    //Making the OnMove method to be called by the Send Message option in the Input System
    public void OnMove(InputValue inputValue){ //Passing input value in as "iV" 

        //Assigning the playerMovement vector2 to the inputvalue vector 2 from the input system
        playerMovement = inputValue.Get<Vector2>() * moveSpeed;
        
        

        //If methods to determine which animation to play
        //Each of these if statements reads the value of the vector2 from player input to decide if player is going up/down/left/right
        if(inputValue.Get<Vector2>().x > 0 && 
        (Mathf.Abs(inputValue.Get<Vector2>().x) > Mathf.Abs(inputValue.Get<Vector2>().y))){

            //Code for runningAnim to the right
            animator.SetBool("IsMoveUp",false);
            animator.SetBool("IsMoveDown",false);
            animator.SetBool("IsMoveRight",true);
            spriteRenderer.flipX = false;

        }else if(inputValue.Get<Vector2>().x < 0 && 
        (Mathf.Abs(inputValue.Get<Vector2>().x) > Mathf.Abs(inputValue.Get<Vector2>().y))){

            //Code for runningAnim to the left
            animator.SetBool("IsMoveUp",false);
            animator.SetBool("IsMoveDown",false);
            animator.SetBool("IsMoveRight",true);
            spriteRenderer.flipX = true;
        
        }else if(inputValue.Get<Vector2>().y > 0 && 
        (Mathf.Abs(inputValue.Get<Vector2>().y) > Mathf.Abs(inputValue.Get<Vector2>().x))){

            //Code for runningAnim up
            animator.SetBool("IsMoveRight",false);
            animator.SetBool("IsMoveDown",false);
            animator.SetBool("IsMoveUp",true);

        }else if(inputValue.Get<Vector2>().y < 0 && 
        (Mathf.Abs(inputValue.Get<Vector2>().y) > Mathf.Abs(inputValue.Get<Vector2>().x))){

            //Code for runningAnim down
            animator.SetBool("IsMoveUp",false);
            animator.SetBool("IsMoveRight",false);
            animator.SetBool("IsMoveDown",true);

        }

    }

//---------------------Section for the Dodge Mechanic-----------------------------------------------------

    //Function for the dodge
    void OnDodge(){

        //Calling the dodge coroutine
        StartCoroutine(incrementDodge());

    }

    //Coroutine called by the OnDodge function
    public IEnumerator incrementDodge(){

        //Setting the increment value for adding force
        float dodgeIncrementValue = dodgeVal/dodgeTimer;

        //For loop to increment the force
        for(int i = 0; i <= dodgeTimer; i++){

            //Testing if the code is functioning properly
            Debug.Log(dodgeIncrementValue);

            //Adding Force to the rigidBody
            rigidBody.AddForce(playerMovement * dodgeIncrementValue);

            //Waiting for a dodgeTimer time
            yield return new WaitForSecondsRealtime((dodgeTimer/10)/50);

        }

    }

//-----------------------------------------Fixed update method--------------------------------------------

    //Fixed Update is called at a more consistent time, instead of every frame so lag doesnt impact it
    void FixedUpdate(){

        //Assigning the vector2 playerMovement to the rigidBody's velocity
        rigidBody.velocity = playerMovement;
        if(Mathf.Approximately(rigidBody.velocity.x,0) && Mathf.Approximately(rigidBody.velocity.y,0)){

            //Setting all the animation triggers to false so the idle anim will play
            animator.SetBool("IsMoveRight",false);
            animator.SetBool("IsMoveUp",false);
            animator.SetBool("IsMoveDown",false);

        }

    }
}
