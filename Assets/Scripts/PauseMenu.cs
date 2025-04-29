using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using StarterAssets;


//Did not manage to figure this out in time, needs to be done later.



public class PauseMenu : MonoBehaviour
{
   

    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public FirstPersonController characterController;


    void Update()
    {
        //Debug code here
        if (PauseMenuUI == null)
        {
            print("No Pause Menu Game Object Assigned.");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

       
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (characterController != null) characterController.enabled = true;
    }


    void Pause() { 
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (characterController != null) characterController.enabled = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame() { 
        Application.Quit();
    }

  
   
}
