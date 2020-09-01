using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite : MonoBehaviour {

    //The The variables below will be used to state how close you need to be and waht angle you need to be with
    //the object to make something happen
    public Transform player;
    public float distance;
    public float angle = 3;

    //The _distance and _angle variable will contain the distance and between the player in the object in the game
    private float _distance;
    private float _angle;
    //The RB variable will be used to access the rigidbody between in the player
    private Rigidbody RB;

    // Use this for initialization
    void Start () {
        // the RB variable it set to the rigidbody component on the stalegmite object.
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        // the _Distance variable will store the value for the distance between the player and the staligmite.
        _distance = Vector3.Distance(this.transform.position, player.transform.position);
        // the _Distance variable will store the value for the angle between the player and the staligmite.
        _angle = Vector2.Angle(transform.position, player.transform.position);

        //If the player is close enought to the stalagmite and is at the right angle then gravity
        //will be applied to the object
        if ( _distance < distance && _angle > angle)
        {
            
            RB.useGravity = true;
        }
	}
}
