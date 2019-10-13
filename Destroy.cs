using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {


    private void OnTriggerEnter(Collider col)
    {
        // if the collider detects an object with the player tag it will destroy it's self
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Detect Player");
            Destroy(gameObject);
        }
    }
}
