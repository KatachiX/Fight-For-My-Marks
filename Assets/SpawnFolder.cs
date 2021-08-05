using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFolder : MonoBehaviour, IClickable
{
    public GameObject folderPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.SetAsLastSibling();
    }

    private void spawnFolder()
    {
        GameObject o = Instantiate(folderPrefab) as GameObject; // add Folder to scene
        o.transform.position = new Vector2(-8.69f, -3.5f);
    }

    public void Click()
    {
        Debug.Log("Spawn Folder");
        if (MoneyManager.instance.UseMoney(100))
        {
            spawnFolder();
        }
    }
}