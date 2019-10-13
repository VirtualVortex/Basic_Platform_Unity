using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    //the code below will spawn objects every two seconds

    //the bullet varaible will contain the bullet object that will be spawned
    public GameObject bullet;
    //The rate variable will be used to state how often the bullets will be fired
    public float rate = 2f;
	// Use this for initialization
	void Start () {
        // the invoke repeating method will run the shoot method from the start of the game every two second
        InvokeRepeating("shoot", 0, rate);
	}

    // The shoot method will spawn the bullet gameObject, at the spawners posiiton and rotation of the spawner;
    void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
