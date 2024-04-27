// Author: Caleb Thurston
// Description: Script to handle the player interacting with objects
// Language: C#endregion


// Plan:
// Tie the physics Overlap circle to the player
// Get the physics overlap circle to return the colliders that are within a certain area
// Display an interact key when player is within a certain distance of an interaction
// Determine some sort of system to tell which interactable object is closest, and have the interaction display for that one

// Notes
// Might have to figure out a way to redefine player reach and player rigidbody to keep position updated



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{

//----------------------Instance Variables--------------------------//
    public Rigidbody2D player; //Rigidbody of the player, so we can keep track of it's position
    private Collider2D[] playerReach;

    

    // Start is called before the first frame update
    void Start()
    {
        
        playerReach = Physics2D.OverlapCircleAll(player.position, 1.0f); //Overlap circle determining the players reach

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    //Fixed update function to use instead of Update
    void FixedUpdate()
    {


        // Could revisit this segment of code to optimize, possibly completely remove the layers from being checked
        // instead of checking if the layer is in the excluded layer, then discarding it
        for (int i = 0; i < playerReach.Length; i++)
        {

            Collider2D collider = playerReach[i];

            if (collider.gameObject.layer != LayerMask.NameToLayer("groundColliders")){ // Checking if the specific collider is on a specific layer

                Debug.Log("Collider: " + collider.name); // Displays the colliders that are close to the player

            }

            

            //Debug.Log("Collider Position: " + collider.transform.position);// Displays the collider positions that are close to the player

        }

    }
}
