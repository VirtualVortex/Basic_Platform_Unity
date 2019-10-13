using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishController : MonoBehaviour {

    //The code for the squish controller is from gareth lewis's workshop and has been modified
    //The code below will control the scale of the object

    //the variables below will be used to control the speed and scale of the objects 
    public float minScale;
    public float maxScale;
    public float scaleTime;
    float currentTime;

    //the delay variable will be used to state how long the object should stay at min or max scale
    public float delay;
    //the timer variable will be used to set how long the object should be delay before scaling up or down
    public float timer;

    //The isScalinUp variable is used to state if the object is increasing in scale
    //and will also be used to state if the currentTime variable needs to increase or decrease its value
    bool isScalingUp;
    

    //At the start currentTime ise set 0 and isScalingUp is set to true
    void Start()
    {
        currentTime = 0;
        isScalingUp = true;
    }

    void Update()
    {
        //the variable temp is set to the tranform relative to the parent transform
        var temp = transform.localScale;

        //The y axis on the temp variable is set to value from the lerp function
        //the value will be created from the minScale variable and the maxScale variable and will change over time by currentTime being divided by scaleTime
        //This will increase or decrease the scale of the object
        temp.y = Mathf.Lerp(minScale, maxScale, currentTime / scaleTime);

        //The transform relative to the parent trasform will be set to the values from the temp variable
        transform.localScale = temp;

        //If isScalingUp is equal to true then current time will be increased by itself plus Time.deltatime
        if (isScalingUp == true)
        {
            currentTime += Time.deltaTime;

            //If currentTime is greater then scaleTime then the timer variable will be equal to iself pluse time.deltatime
            if (currentTime > scaleTime)
            {
                timer += Time.deltaTime;

                //If timer is greater than delay then current time is equal to scaletime, isScalingUp is equal to false and timer = 0.0
                if (timer > delay)
                {
                    currentTime = scaleTime;
                    isScalingUp = false;
                    timer = 0.0f;
                }
            }
        }
        //else curentTime is equal to iself minus Time.delta time which will move the object back to the min scale
        //until current time is smaller than zero at which point the process will be repeated.
        else
        {
            currentTime -= Time.deltaTime;

            
            if (currentTime < 0)
            {
                currentTime = 0;
                isScalingUp = true;
            }
        }
    }
}
