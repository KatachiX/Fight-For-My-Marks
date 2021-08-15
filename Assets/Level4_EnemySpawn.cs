using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_EnemySpawn : MonoBehaviour
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
        if(enemyBase.GetComponent<Base>().stats.curHealth < 500 && phase == 1)
        {
            Debug.Log("phase 2");
            phase = 2;
            StopCoroutine(spawnWave());
            StartCoroutine(spawnWave2());
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

        spawnEnemyPaper();
        yield return interval;
        spawnEnemyPaper();
        yield return interval;

        yield return new WaitForSeconds(2.0f);

        spawnEnemyEraser();
        yield return interval;
        spawnEnemyEraser();
        yield return interval;
        spawnEnemyEraser();
        yield return interval;

        yield return new WaitForSeconds(10.0f);

        for(int i = 0; i < 5; i++)
        {
            spawnEnemyPaper();

            yield return new WaitForSeconds(9.0f);

            spawnEnemyEraser();

            yield return new WaitForSeconds(9.0f);

            spawnEnemyPencil();

            yield return new WaitForSeconds(9.0f);

        }
    }

    IEnumerator spawnWave2()
    {
        for(int i = 0; i < 10; i++)
        {
            spawnEnemyPaper();
            yield return new WaitForSeconds(0.5f);
        }

        spawnEnemyStapler();

        yield return new WaitForSeconds(20.0f);

        for(int i = 0; i < 5; i++)
        {
            spawnEnemyPaper();

            yield return new WaitForSeconds(0.5f);

            spawnEnemyEraser();

            yield return new WaitForSeconds(0.5f);

            spawnEnemyPencil();

            yield return new WaitForSeconds(0.5f);
        }

        while(true)
        {
            spawnEnemyPencil();

            yield return new WaitForSeconds(8.0f);

            spawnEnemyPencil();

            yield return new WaitForSeconds(8.0f);

            spawnEnemyPaper();

            yield return new WaitForSeconds(8.0f);

            spawnEnemyEraser();

            yield return new WaitForSeconds(8.0f);
        }
    }
}
