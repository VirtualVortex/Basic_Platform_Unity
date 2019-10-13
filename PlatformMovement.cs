using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    //The code for the squish controller is from gareth lewis's workshop
    //This script allows platforms to move from a to b and vice versa

    //the startPos and endPos variable will be used to state the two points the object should move to
    public Vector2 startPos;
    public Vector2 endPos;

    //the journeyTime variable will state how long the it will take for the object to move from a to b
    public float journeyTime;
    //the player variable will contain the player object
    public GameObject player;

    //The isOnOutboundLeg variable will be used to state if the object is at the startPos
    bool isOnOutboundLeg;
    //The currenTime variable will be used to increase or decrease the journeyTime variable which will move the object left or right
    float currentTime;


    //At the start isOnOutboundLeg will be set to false and currentTime will be set to 0
    void Start()
    {
        isOnOutboundLeg = false;
        currentTime = 0;
    }

    void Update()
    {
        //The pos variable is set to the transform relative to the parent transform
        var pos = transform.localPosition;

        //The tempPos variable is equal to the value between the start and end position 
        //The currentTime and journey time is used to move the object forwards and backwards or up of down.
        var tempPos = Vector2.Lerp(startPos, endPos, currentTime / journeyTime);

        //the x and y axis of the pos variable is equal to the x and y of the tempPos variable
        pos.x = tempPos.x;
        pos.y = tempPos.y;

        //The transform relative to the parent transform is equal to the values in the pos variable.
        transform.localPosition = pos;

        //If the isOnOutboundLeg variable is equal to true then the currentTime variable is equal to itself pluse Time.deltaTime
        if (isOnOutboundLeg == true)
        {
            currentTime += Time.deltaTime;

            //If current time is greater than journeyTime then currentime is equal to journeyTime and isOnOutboundleg is equal to false
            if (currentTime > journeyTime)
            {
                currentTime = journeyTime;
                isOnOutboundLeg = false;
            }
        }
        //Else currentTime is equal to itself minus Time.deltatime
        else
        {
            currentTime -= Time.deltaTime;

            //If currentTime is smaller than 0 then currentTime is equal to 0 and isOnOutboundLeg = true;
            if (currentTime < 0)
            {
                currentTime = 0;
                isOnOutboundLeg = true;
            }
        }
    }

    
}
