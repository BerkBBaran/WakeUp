using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScreen : MonoBehaviour
{
    public void QuitGame()
    {
        // Exit game
        Application.Quit();
    }

    public void StartGame()
    {
        //Loading next scene after the menu
        SceneManager.LoadScene(0);
    }

}
