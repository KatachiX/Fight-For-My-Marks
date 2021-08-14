using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Level 1
public class Level3_EnemySpawn : MonoBehaviour
{
    public GameObject enemyPencilPrefab;
    public GameObject enemyPaperPrefab;
    public GameObject enemyEraserPrefab;
    public GameObject enemyStaplerPrefab;
    public GameObject enemyFolderPrefab;
    public GameObject enemyBase;

    public WaitForSeconds interval = new WaitForSeconds(0.25f);
    
    public float vectX = 8.69f;
    public float vectY = -3.5f;

    public int phase = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyBase.GetComponent<Base>().stats.curHealth != 500 && phase == 1)
        {
            Debug.Log("phase 2");
            phase = 2;
            StopCoroutine(spawnWave());
            StartCoroutine(spawnWave2());
        }
        if(enemyBase.GetComponent<Base>().stats.curHealth <= 250 && phase == 2)
        {
            Debug.Log("phase 3");
            phase = 3;
            StopCoroutine(spawnWave2());
            StartCoroutine(spawnWave3());
        }
    }

    private void spawnEnemyPencil(){
        GameObject pencil = Instantiate(enemyPencilPrefab) as GameObject;
        pencil.transform.position = new Vector2(vectX, vectY);
    }
    private void spawnEnemyPaper(){
        GameObject paper = Instantiate(enemyPaperPrefab) as GameObject;
        paper.transform.position = new Vector2(vectX, vectY);
    }
    private void spawnEnemyEraser(){
        GameObject eraser = Instantiate(enemyEraserPrefab) as GameObject;
        eraser.transform.position = new Vector2(vectX, vectY);
    }
    private void spawnEnemyStapler(){
        GameObject stapler = Instantiate(enemyStaplerPrefab) as GameObject;
        stapler.transform.position = new Vector2(vectX, vectY);
    }

    private void spawnEnemyFolder(){
        GameObject folder = Instantiate(enemyFolderPrefab) as GameObject;
        folder.transform.position = new Vector2(vectX, vectY);
    }

    IEnumerator spawnWave(){

        yield return new WaitForSeconds(5f);

        spawnEnemyFolder();
        
        yield return new WaitForSeconds(5f);

        spawnEnemyPencil();
        yield return interval;
        spawnEnemyPencil();
        yield return interval;
        spawnEnemyPencil();
        yield return interval;

        yield return new WaitForSeconds(60f);

        spawnEnemyEraser();
        yield return interval;
        spawnEnemyEraser();
        yield return interval;
    }

    IEnumerator spawnWave2(){

        spawnEnemyFolder();
        yield return interval;
        spawnEnemyEraser();
        yield return interval;
        spawnEnemyEraser();
        yield return interval;
        spawnEnemyEraser();
        yield return interval;
        spawnEnemyEraser();
        yield return interval;
        spawnEnemyEraser();
        yield return interval;

    }

    IEnumerator spawnWave3(){

        spawnEnemyPencil();
        yield return interval;
        spawnEnemyPencil();
        yield return interval;
        spawnEnemyPencil();
        yield return interval;
        spawnEnemyStapler();
                
    }
}
