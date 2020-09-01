using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	//The code below controls the start menu and quit menu
	
	void Update () {

        //if the scene name is equal to EndScene then the cursors isn't locked in place and is made visible
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EndScene"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
	}

    //the function below will be used by the button to take the player to the firt level
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    //the function below will be used by a button to allow the user to leave the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
