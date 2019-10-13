using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContorller : MonoBehaviour {

    //The code the implements Moving, Jumping and Gravity has come from the Unity manual
    //URL: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
    //The code that allows the playe rto move in the air, I created myself

    //The characterController variable will be used to gain access tothe character controller componet
    CharacterController characterController;

    //The speed variable will determin how fast the chaaracter needs to move
    public float speed = 6.0f;
    //The speed boost will allow the player to move at the same speed when time slows down
    public float speedBoost = 3.0f;
    //The jumpSpeed variable will state how high the character will jump
    public float jumpSpeed = 8.0f;
    //The grvavity variable will used to state how strong the gravity will be in the virtual world
    public float gravity = 20.0f;

    public static bool isDead = false;
    //The count variable will be used for a timer which states how long time should be slowed down
    public float count;
    //The bounceForce variable will be used to determin how high the player will be pushed up
    public float bounceForce;
    //the couting variable will be used to turn the counter on and off
    public bool counting = false;
    //The message variable will contain the message object which will be set to active and not active
    public GameObject message;
    //the timer variable will be used to state how long the message should be displayed
    public float timer;
    //The hitbutton variable will be used to tell the drain script to decrease the scale of the lava
    public static bool hitButton;
    //The message2 variable will contain the second message object which will be set to active and not active
    public GameObject message2;

    //the moveDirection variable will be set to zero on the x,y and z variable which will
    //the variable will store the position of the player 
    private Vector3 moveDirection = Vector3.zero;
    //the hasClock variable will be used to state if the player has the clock
    private bool hasClock = false;
    //the hasClock variable will be used to state if the player has the key
    private bool hasKey = false;

    

    //At the start the character controller variable is connected with the charactercontroller on the player object
    //Also the isDead variable is set to false. This will make the Death menu disapear
    //Also the timer variable is set to zero, this will reset the timer for the messages
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        isDead = false;
        timer = 0.0f;
    }

    void Update()
    {

        // If the player is on the ground then the code below will run
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= speed;

            //if the space button is pressed then the moveDirection on the y axis is equal to the jumpSpeed
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
       

        // This will allow the player to move
        characterController.Move(moveDirection * Time.deltaTime);

        
        // if the character isn't grounded then the user will be able to move around in the air while also move down to the ground.
        if (!characterController.isGrounded)
        {
            
            moveDirection = new Vector3(Input.GetAxis("Horizontal")*speed, moveDirection.y -= gravity * Time.deltaTime, 0.0f);
        }

        //this will run the timeController method
        timeController();


        //when the hitButton is equal to true then the timer starts
        if (hasClock == true)
        {
            timer += Time.deltaTime;
        }
        

        //when the hitButton is equal to true then the timer starts
        if (hitButton == true)
        {
            timer += Time.deltaTime;
        }
        

        // When the value in the timer variable is over 2.5 and the has clock variable is equal to true
        //then the text message will disapear.
        if (timer > 2.5f && hasClock == true)
        {
            message.SetActive(false);
            timer = 0.0f;
        }

        // When the value in the timer variable is over 3 and the hitbutton variable is equal to true
        //then the text message will disapear.
        if (timer > 2 && hitButton == true)
        {
            message2.SetActive(false);
            timer = 0.0f;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        //If the player object detects an object with the tag Lava it will 
        //Set the isDead variable to true and destroy the game object.
        if (col.gameObject.CompareTag("Danger"))
        {
            isDead = true;
            Destroy(gameObject);
            Time.timeScale = 1.0f;
        }

        //if the player collides with an dobject with the door tag and thet the hasKey bool is set to true
        // then the user will be moved to the second scene.
        if(col.gameObject.tag == "Door" && hasKey == true) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //player collides with an object that has the Platform tag then it will be made a child of the object
        //and the message "On platfor" will be displayed.
        if (col.gameObject.CompareTag("Platform"))
        {
            Debug.Log("On platfor");
            transform.parent = col.transform;
        }

        //if the player collides with an object that has the Key then the hasKey variable is set to true
        if (col.gameObject.CompareTag("Key"))
        {
            Debug.Log("Got key");
            hasKey = true;
        }

        //if the player collides with an object with the Bouncepad tag then the moveDirection on the y axis will be equal to the value in the bounce force variable
        if (col.gameObject.CompareTag("Bouncepad"))
        {
            moveDirection.y = bounceForce;
        }

        //if the player collides with an object with the Time tag then the hasClock bool variable will be set to true;
        //also the message gameobject will be active;
        if (col.gameObject.CompareTag("Time"))
        {
            Debug.Log("Grabbed clock");
            hasClock = true;
            message.SetActive(true);
        }

        //if the player collides with an object with the Button tag then the hasClock bool variable will be set to true;
        //also the message gameobject will be active;
        if (col.gameObject.CompareTag("Button"))
        {
            Debug.Log("hit button");
            hitButton = true;
            message2.SetActive(true);
        }
           
    }

    //when the player exits the collider then it is no longer a child of the parent it collides with
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Off platform");
        transform.parent = null;
    }

    //The function below will allow the player to slow down time for 4 seconds
    void timeController()
    {
        //When counting is set to true the count's value is increased
        // Also the speed of the player movement is increase to keep the speed of the player the same
        // when time slows down;
        if (counting == true)
        {
            count += Time.deltaTime;
            moveDirection.x *= speedBoost;
        }

        //if the user right clicks and hasClock is set to true then counting is set to true.
        if (Input.GetMouseButton(1) && hasClock == true)
        {
            counting = true;

            //if count is smaller then 3 then time is slowed down by half
            if (count < 3)
            {
                Time.timeScale = 0.5f;
                Debug.Log("Time slowing down");
            }
        }

        //if count greater than 2 then time is sped back up to normal, count is equal to zero and counting is equal to false.
        if (count > 2)
        {
            Debug.Log("Time normal");
            Time.timeScale = 1.0f;
            count = 0;
            counting = false;
        }
    }
}
