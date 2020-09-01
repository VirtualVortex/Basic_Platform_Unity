using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    //The code for the squish controller is from gareth lewis's workshop
    //This script allows platforms to move from a to b and vice versa

    //the startPos and endPos variable will be used to state the two points the object should move to
    public Vector2 startPos;
    public Vector2 endPos;
    //the journeyTime variable will state how long the it will take for the object to move from a to b
    public float journeyTime;
    //The currenTime variable will be used to increase or decrease the journeyTime variable which will move the object left or right
    float currentTime;
    //The isOnOutboundLeg variable will be used to state if the object is at the startPos
    bool isOnOutboundLeg;
    

    

    void Start()
    {
        // at the start isOnOutboundLeg is equal to false and currentTime is equal to zero
        isOnOutboundLeg = false;
        currentTime = 0;
    }

    void Update()
    {
        //the variable pos it set to the position relative to the parent trasnform.
        var pos = transform.localPosition;

        //the tempPos variable is equal to the value from the lerp function which contains
        //the start position, the end position and the time it would take to get from a to b
        //The currentTime and journey time is used to move the object forwards and backwards or up of down.
        var tempPos = Vector2.Lerp(startPos, endPos, currentTime / journeyTime);

        // the x and y axis of the pos variable are equal to the x and y axis of the tempPos variable
        pos.x = tempPos.x;
        pos.y = tempPos.y;

        // the position relative to the parent transform is equal to the values from the pos variable
        transform.localPosition = pos;

        //if the isOnOutboundleg bool is equal to true then the currentTime variale is equal to its self plus time.deltatime
        if (isOnOutboundLeg == true)
        {
            currentTime += Time.deltaTime;

            // if the currentTime varaible is greater the journeyTime variable then
            //currentTime is equal to journeyTime and the isOnOutboundLeg = false
            if (currentTime > journeyTime)
            {
                currentTime = journeyTime;
                isOnOutboundLeg = false;
            }
        }
        // else //if the isOnOutboundleg bool is equal to true then the currentTime variale is equal to its self minus time.deltatime
        else
        {
            currentTime -= Time.deltaTime;

            //and if currentTime < 0 then currentTime is equal to 0 and isOnOutboundLeg is equal to true
            if (currentTime < 0)
            {
                currentTime = 0;
                isOnOutboundLeg = true;
            }
        }
    }
}
