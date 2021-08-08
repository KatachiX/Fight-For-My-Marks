using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    public GameObject enemyBase;
    public GameObject allyBase;
    public GameObject winScreen;
    public GameObject loseScreen;
    public static bool WinGame = false;
    public static bool LoseGame = false;

    void Start() 
    {
        WinGame = false;
        LoseGame = false;
        if (gm == null)
        {
            gm = this;
        }
    }

    void Update(){
        if(enemyBase == null && !WinGame){
            WinGame = true;
            GetComponent<PauseMenu>().enabled = false;
            WinLevel();
        }

        if(allyBase == null && !LoseGame){
            LoseGame = true;
            GetComponent<PauseMenu>().enabled = false;
            LoseLevel();
        }
    }

    void WinLevel(){
        winScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void LoseLevel(){
        loseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void NextLevelButton(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //arrange buildindex in order for levels, check if level is 3, hide this button
    }

    public void TryAgainButton(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitLevelButton(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level Selector");
    }
}