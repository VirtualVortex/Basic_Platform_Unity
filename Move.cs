using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    //The code below will control the speed and direction of the bullet object and destroy the object after 3 seconds

    //the speed variable will be used to state how fast the object shoud move
    public float speed = 2f;
    //the counter variable will be used to state how long the object should be in the game before being destroyed
    public float counter;

	
	
	// Update is called once per frame
	void Update () {
        // the code below will move the object to the right by the speed of the speed vairable
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        //The code below will increase the counter variable by itself pluse Time.deltatime
        counter += Time.deltaTime;

        //If counter is greater than 3 then the object will be destroyed
        if (counter > 3)
        {
            Destroy(gameObject);
        }
	}

    
}
