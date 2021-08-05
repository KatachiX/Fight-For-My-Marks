using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEraser : MonoBehaviour, IClickable
{
    public GameObject eraserPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.SetAsLastSibling();
    }

    private void spawnEraser()
    {
        GameObject o = Instantiate(eraserPrefab) as GameObject; // add Eraser to scene
        o.transform.position = new Vector2(-8.69f, -3.5f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log("Spawn Eraser");
        if (StaminaBar.instance.UseStamina(40))
        {
            spawnEraser();
        }
    }
}