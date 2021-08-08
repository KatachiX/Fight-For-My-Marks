using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBGMusic : MonoBehaviour
{
    static bool musicOn = false;
    void Awake() {
        if(musicOn){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(transform.gameObject);
            musicOn = true;
        }
    }
}
