using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tip());
    }

    IEnumerator Tip()
    {
        yield return new WaitForSeconds(5.0f);

        GameMaster.Destroy(this.gameObject);
    }
}
