using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {

    //The code below will add a force to the player

    //the variables below access the rigibody in the object and will add force a specific amount of force to the player
    Rigidbody RB;
    public float ApplyForce;

	// Use this for initialization
	void Start () {
        
        RB = GetComponent<Rigidbody>();
        
    }
	
	// Update is called once per frame
    
	void Update () {

        //The code below will be used to controls how far the object can go before dropping down and then apply force to bring it back up

        //if the object's y position on the y axis is below - 21
        // then the velocity is set to zero and force is applied to make the object move upwards.
        if (transform.position.y < -21)
        {
            RB.velocity = Vector3.zero;
            RB.AddForce(new Vector3(0, ApplyForce, 0));
        }
        //if the object's y position is over -5 then the velocity of the object will be set to zero.
        else if (transform.position.y > -5)
        {
            RB.velocity = Vector3.zero;
        }
	}
}
