using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5_EnemySpawn : MonoBehaviour
{
    public GameObject enemyPencilPrefab;
    public GameObject enemyPaperPrefab;
    public GameObject enemyEraserPrefab;
    public GameObject enemyStaplerPrefab;
    public GameObject enemyFolderPrefab;
    public GameObject enemyRulerPrefab;
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
        if(enemyBase.GetComponent<Base>().stats.curHealth < 1000 && phase == 1)
        {
            Debug.Log("phase 2");
            phase = 2;
            StopCoroutine(spawnWave());
            //StartCoroutine(spawnWave2());
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

    private void spawnEnemyRuler(){
        GameObject ruler = Instantiate(enemyRulerPrefab) as GameObject;
        ruler.transform.position = new Vector2(vectX, vectY);
    }

    IEnumerator spawnWave()
    {
        yield return new WaitForSeconds(5.0f);
        
        for(int i = 20; i > 0; i--)
        {
            float wait = 0.0f + i/3;

            spawnEnemyPencil();

            yield return new WaitForSeconds(wait);
        }

        spawnEnemyFolder();
        yield return interval;
        spawnEnemyRuler();
        yield return interval;
        spawnEnemyRuler();
        yield return interval;
        spawnEnemyRuler();
        yield return interval;

        yield return new WaitForSeconds(20.0f);

        for(int i = 0; i < 5; i++)
        {
            spawnEnemyPencil();
            yield return interval;
        }

        spawnEnemyStapler();
        yield return interval;
        spawnEnemyStapler();
        yield return interval;

        yield return new WaitForSeconds(20.0f);

        spawnEnemyFolder();
        yield return interval;
        spawnEnemyFolder();
        yield return interval;
    }

    // IEnumerator spawnWave2()
    // {

    // }
}
