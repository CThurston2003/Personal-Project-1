using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Adding the possibility for more complicated reads from the input system

public class PlayerControls : MonoBehaviour
{

    
    //Creating a reference to the players rigidbody
    public Rigidbody2D rigidBody;

    //Creating a reference to the players inputs
    private PersonalProject1 personalProject1;

    //Creating a reference to player moveSpeed
    [SerializeField] private float moveSpeed;


    //Vector 2 Variable to store the movement of the player to later be assigned in update
    Vector2 playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        //Tying the rigidbody and personal project to itself (Not sure if I really need these, as to why they're permanently commented out)
        //rigidBody = GetComponent<Rigidbody2D>();
        //personalProject1 = new PersonalProject1();

    }

    //Making the OnMove method to be called by the Send Message option in the Input System
    public void OnMove(InputValue inputValue){ //Passing input value in as "iV" 

        //Assigning the playerMovement vector2 to the inputvalue vector 2 from the input system
        playerMovement = inputValue.Get<Vector2>() * moveSpeed;
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    //Fixed Update is called at a more consistent time, instead of every frame so lag doesnt impact it
    void FixedUpdate(){

        //Assigning the vector2 playerMovement to the rigidBody's velocity
        rigidBody.velocity = playerMovement;

    }
}
