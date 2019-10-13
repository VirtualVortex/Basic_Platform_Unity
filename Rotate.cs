using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    // how fast the object should rotate
	public float speed;

    // the three boolian variables bellow will be used to tell the object which axises to rotate on
	public bool x;
	public bool y;
	public bool z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        //if the x vairable is set to true then run the x method
		if(x == true)
		{
			X();
		}
        //if the x vairable is set to true then run the y method
        if (y == true)
		{
			Y();
		}
        //if the x vairable is set to true then run the z method
        if (z == true)
		{
			Z();
		}
	}
    //The x void bellow will make the object rotate on the x axis at the speed value mulitpled by delta time.
    void X ()
	{
		transform.Rotate(new Vector3(speed,0,0)*Time.deltaTime);
	}
    //The y void bellow will make the object rotate on the y axis at the speed value mulitpled by delta time.
    void Y ()
	{
		transform.Rotate(new Vector3(0,speed,0)*Time.deltaTime);
	}
    //The z void bellow will make the object rotate on the z axis at the speed value mulitpled by delta time.
    void Z ()
	{
		transform.Rotate(new Vector3(0,0,speed)*Time.deltaTime);
	}
}
