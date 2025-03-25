using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


//Did not manage to figure this out in time, needs to be done later.



public class PauseMenu : MonoBehaviour
{
    public GameObject pause;



    bool isPaused;

    public void RestartGame()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.buildIndex);

        // Reset the mouse cursor state
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
}


    public void QuitGame() { 
        Application.Quit();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            Cursor.visible = isPaused ? true : false;
		    pause.SetActive(isPaused);

        }
    }
}
