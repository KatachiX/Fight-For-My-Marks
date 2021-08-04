using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPencil : MonoBehaviour, IClickable
{
    public GameObject pencilPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.SetAsLastSibling();
    }

    private void spawnPencil()
    {
        GameObject o = Instantiate(pencilPrefab) as GameObject; // add Pencil to scene
        o.transform.position = new Vector2(-8.69f, -3.5f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log("Run");
        if (StaminaBar.instance.UseStamina(20))
        {
            spawnPencil();
        }
    }
}