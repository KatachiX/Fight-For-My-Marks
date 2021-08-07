using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStapler : MonoBehaviour, IClickable
{
    public GameObject StaplerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.SetAsLastSibling();
    }

    private void spawnStapler()
    {
        GameObject o = Instantiate(StaplerPrefab) as GameObject; // add Stapler to scene
        o.transform.position = new Vector2(-8.69f, -3.5f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log("Spawn Stapler");
        if (StaminaBar.instance.UseStamina(60))
        {
            spawnStapler();
        }
    }
}