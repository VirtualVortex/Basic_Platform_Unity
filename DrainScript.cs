using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainScript : MonoBehaviour {

    //The code below will make the scale of the lava object decrease
    //The code for the squish controller is from gareth lewis's workshop and has been modified

    //the minScale will be used to contain the minimum value that the lerp function will use
    public float minScale;
    //the maxScale will be used to contain the maximum value that the lerp function will use
    public float maxScale;
    //The scaleTime varaible will be used to state how fast the scale of the object will change
    public float scaleTime;

    //The currenTime variable will be used to increase or decrease the journeyTime variable which will increase or decrease the scale of the object
    float currentTime;

    void Start()
    {
        currentTime = 0;  
    }

    void Update()
    {
        //the temp variable is set to the localscale from the transform relative to the parent
        var temp = transform.localScale;

        
        //if the Player hits the button then the code below will make the scale of the lava object decrease
        if (PlayerContorller.hitButton == true)
        {
            //the value in the currentTime variable will increase by one
            currentTime += Time.deltaTime;

            //The value in the y axis in localscale will be set to the value from the lerp method
            // and wll move at the time determined by the current time divied by the scale time
            //in this case the object will only scale down.
            temp.y = Mathf.Lerp(minScale, maxScale, currentTime / scaleTime);

            //the localscape is then made equal to the values int the temp variable.
            transform.localScale = temp;
        }


    }
}
