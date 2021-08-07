using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;

    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GamePaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void PauseButton(){
        Pause();
    }

    public void ResumeButton(){
        Resume();
    }

    public void ExitButton(){
        Resume();
        SceneManager.LoadScene("Level Selector");
    }
}
