using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void QuitGame()
    {   
        // Exit game
        Application.Quit();
    }

    public void StartGame()
    {   
        //Loading next scene after the menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SoundChange()
    {
        if (AudioListener.volume == 1)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;
    }
}
