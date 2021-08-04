using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPaper : MonoBehaviour, IClickable
{
    public GameObject paperPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.SetAsLastSibling();
    }

    private void spawnPaper()
    {
        GameObject o = Instantiate(paperPrefab) as GameObject; // add Paper to scene
        o.transform.position = new Vector2(-8.69f, -3.5f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log("Spawn Paper");
        if (StaminaBar.instance.UseStamina(30))
        {
            spawnPaper();
        }
    }
}