using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRuler : MonoBehaviour, IClickable
{
    public GameObject rulerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.SetAsLastSibling();
    }

    private void spawnRuler()
    {
        GameObject o = Instantiate(rulerPrefab) as GameObject; // add Ruler to scene
        o.transform.position = new Vector2(-8.69f, -3.5f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log("Spawn Ruler");
        if (MoneyManager.instance.UseMoney(50))
        {
            spawnRuler();
        }
    }
}