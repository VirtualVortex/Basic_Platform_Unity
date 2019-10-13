using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

    //the code here has come from brackeys pause menu video and has been modified
    //This is the URL: https://www.youtube.com/watch?v=JivuXdrIHK0
    //The code below will bring up and control the death and pause menu

    //the two gameobject variables below will contain the objects that have the UIs for the menus
    public GameObject restart;
    public GameObject pause;

    // Use this for initialization
    void Start () {

        //The code below will set the cursor to be locked into position and make the cursor invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

        //The if statement will check to see if the variable isDead in the PlayerController program is set to true
        if (PlayerContorller.isDead == true)
        {
            //The code bellow will activate the Gameobject containing the text and button for the death page 
            //thus making it appear to the player
            restart.SetActive(true);

            //The code below will set the cursor to no longer be locked in place and won't be invisible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        // if the escape button is pressed then time will stop, the pause game object that contains the text and buttons
        //will be activated and the cursor will be made visible and locked out of position.
        if (Input.GetKey(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        

    }

    //the methods below will reload the current scene the player is in
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //the method below when active will diactivate the pause gameobject, unpause time
    //and made the cursor invisible while also locking it back into position.
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //when the method below is run the build of the game will close
    public void Quit()
    {
        Application.Quit();
    }
}
