using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() {

        SceneManager.LoadSceneAsync(1);

        //Hide the mouse cursor after loading the next scene
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CreditsScreen() {
        SceneManager.LoadSceneAsync(2);
    }

    public void BackToMainMenu() {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame() { 
        Application.Quit();
    }
}
