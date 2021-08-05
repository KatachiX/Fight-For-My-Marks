using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public void StartGame(){
        SceneManager.LoadScene("Level Selector"); //Load the first level (May have to put in a cut scene)
    }

    public void OpenOptions(){
        optionsMenu.SetActive(true);
    }

    public void CloseOptions(){
        optionsMenu.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
