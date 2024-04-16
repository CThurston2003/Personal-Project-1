using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Immediate notes for Future reference
//Try using CoRoutines to determine when the npcs walk
    //I'm thinking for the basic implementation, have it decide a random number 1 through 4, each number mapped to 
    //a direction. Once the number is decided, then the NPC goes in that direction for a second or 2, and then stops
    //And it runs again (Could also map the directions to +1 to -1 in both directions)
//Possibly try to use transform to move the NPC instead of vectors with rigidBody


public class NPC_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//-----------------------------------------Area for coding NPC wandering--------------------------------------------

//Using the Fixed update method so it calls the coroutine every update

    void FixedUpdate(){



    }


    //--------Defining the IEnumerator for the npc Wandering-------
    public IEnumerator npcWander()

}
