using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tip : MonoBehaviour
{
    public float wait = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tip());
    }

    IEnumerator Tip()
    {
        yield return new WaitForSeconds(wait);

        GameMaster.Destroy(this.gameObject);
    }
}
