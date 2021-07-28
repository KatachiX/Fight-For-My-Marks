using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    void Start() 
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public static void KillPencil(Pencil pencil) {
        Destroy (pencil.gameObject);
    }
}