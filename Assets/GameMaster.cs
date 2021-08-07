using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    public GameObject enemyBase;
    public bool WinGame = false;

    void Start() 
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    void Update(){
        if(enemyBase == null){
            EndLevel();
        }
    }

    public void EndLevel(){
        Time.timeScale = 0.0f;
        WinGame = true;
    }
}