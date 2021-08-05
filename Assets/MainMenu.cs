using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Level 1"); //Load the first level (May have to put in a cut scene)
    }

    public void OptionsMenu(){
        SceneManager.LoadScene("Options");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
