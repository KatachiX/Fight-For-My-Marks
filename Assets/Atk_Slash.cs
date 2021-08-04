using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_Slash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.2f);
        GameMaster.Destroy(this.gameObject);
    }

    

    // Update is called once per frame
    void Update()
    {

    }
}
