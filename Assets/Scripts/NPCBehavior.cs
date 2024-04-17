/// Author: Caleb Thurston
/// Description: Basic NPC behavior for basic NPCs including basic random wandering
/// Language: C#
/// Date Created: Forgot to mark the exact day, so first day I'm doing considerable work on it (4/16/2024)



//-----------------------------------------------------Imports--------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Things to implement in the future
// For npc wandering to not cause NPCs to repeatedly walk into walls
// Fix npc being sent sliding by colliding with objects like the player

public class NPCBehavior : MonoBehaviour
{
//--------------------------Public Variables to be editable in unity--------------------------------

    public int wanderForce = 5; //Wander force for the npcs
    public Rigidbody2D npcBody; //Reference to the NPCs rigidbodies
    Vector2 npcMovement; //Vector2 object for the NPC's velocity
    public float coolDown = 5f; //Amount of seconds to wait before NPC walks again
    float lastWalked = 0f; // Variable to keep track of the last time the NPC walked
    public float walkTime = 1; // Variable to control how long the npc will walk for

//--------------------------------------Start Method---------------------------------------
    void Start()
    {
    }
//--------------------------------------Update Method--------------------------------------
    void Update()
    {
    }
//-----------------------------------------Area for coding NPC wandering--------------------------------------------

//Using the Fixed update method so it calls the coroutine every update

    void FixedUpdate(){

        // Call the Coroutine
        StartCoroutine(npcWander());

    }


    //----------------------------------Defining the IEnumerator for the npc Wandering------------------------------
    public IEnumerator npcWander(){ 

        //Check to see if cooldown has passed
        if (lastWalked > coolDown){

            // Resetting lastWalked so it will trigger when the cooldown timer is up again
            lastWalked = 0;

//--------------------------------------------------Direction Control---------------------------------------------------------------

            // 1 is Up, 2 is Right, 3 is Down, 4 is Left
            int randomDirection = Random.Range(1, 5); //Deciding which direction to go in

            // Going Up!
            if (randomDirection == 1){

                //Setting the npc velocity and adding that velocity to the Rigidbody
                npcMovement = new Vector2(0,wanderForce);
                npcBody.velocity = npcMovement;
            
            // Going Right!
            }else if(randomDirection == 2){

                //Setting the npc velocity and adding that velocity to the Rigidbody
                npcMovement = new Vector2(wanderForce,0);
                npcBody.velocity = npcMovement;
            
            // Going Down!
            }else if(randomDirection == 3){

                //Setting the npc velocity and adding that velocity to the Rigidbody
                npcMovement = new Vector2(0,-wanderForce);
                npcBody.velocity = npcMovement;

            //Going Left! 
            }else if(randomDirection == 4){

                //Setting the npc velocity and adding that velocity to the Rigidbody
                npcMovement = new Vector2(-wanderForce,0);
                npcBody.velocity = npcMovement;
            
            }

//-------------------------------------------------End of Direction Control----------------------------------------------------

            //Wait a couple seconds before changing velocity
            yield return new WaitForSecondsRealtime(walkTime);
            
            //Resetting velocity of npc
            npcMovement = new Vector2(0,0);
            npcBody.velocity = npcMovement;
            
        }else{

            // Incrementing lastWalked based on the amount of Real Time passed
            lastWalked += Time.deltaTime;

        }


    }

//-----------------------------------------------------End of NPC wandering--------------------------------------------

}
