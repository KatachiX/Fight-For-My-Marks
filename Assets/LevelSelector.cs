using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LevelOne(){
        SceneManager.LoadScene("Level 1");
    }
    public void MainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}
