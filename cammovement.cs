using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammovement : MonoBehaviour {

    //The code below will control how th camera follows the player

    //the player variable will be used to set the position of the camera and state if the player is dead or not
    public Transform player;

    //The camZPos variable has a defelt number -10 and used to tell the camera how far back it needs to be on the z axis 
    public int camZPos = -10;

    //The comYPos variable will be used to state how high up the camera needs to be when pointed at the player
    public int camYPos;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if the player isn't dead then the camera's x position will be equal to the player's x position
        //the camers y position will be equal to the player's y posiotn plus the value from the camYPos variable
        //and the camer's z position will be set to the value in the camZpos
        if(PlayerContorller.isDead == false)
        {
            transform.position = new Vector3(player.position.x,player.position.y+camYPos, camZPos);
        }
    }

    
}
