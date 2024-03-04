
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


    // Start is called before the first frame update
    void Start()
    {
        //Tying the rigidbody and personal project to itself
        rigidBody = GetComponent<Rigidbody2D>();
        personalProject1 = new PersonalProject1();

    }

    //Making the OnMove method to be called by the Send Message option in the Input System
    public void OnMove(InputValue inputValue){ //Passing input value in as "iV" 

        //Assigning the velocity of the rigidBody to the input value gotten from a vector2 and multiplied by moveSpeed
        rigidBody.velocity = inputValue.Get<Vector2>() * moveSpeed;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
