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
    public GameObject enemyBossPrefab;
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
        if(enemyBase.GetComponent<Base>().stats.curHealth <= 1500 && phase == 1)
        {
            Debug.Log("phase 2");
            phase = 2;
            StopCoroutine(spawnWave());
            StartCoroutine(spawnWave2());
        }

        if(enemyBase.GetComponent<Base>().stats.curHealth <= 1000 && phase == 2)
        {
            Debug.Log("phase 3");
            phase = 3;
            StopCoroutine(spawnWave2());
            StartCoroutine(spawnWave3());

            enemyBase.GetComponent<Base>().stats.curHealth = 1000;
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

    private void spawnEnemyBoss(){
        GameObject boss = Instantiate(enemyBossPrefab) as GameObject;
        boss.transform.position = new Vector2(vectX, vectY);
    }

    private void spawnEnemyRuler(){
        GameObject ruler = Instantiate(enemyRulerPrefab) as GameObject;
        ruler.transform.position = new Vector2(vectX, vectY);
    }

    IEnumerator spawnWave()
    {
        yield return new WaitForSeconds(5.0f);

        spawnEnemyBoss();
        
        for(int i = 20; i > 0; i--)
        {
            float wait = 0.0f + i/3;

            spawnEnemyPencil();

            yield return new WaitForSeconds(wait);
        }

        yield return new WaitForSeconds(20.0f);

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

    IEnumerator spawnWave2()
    {
        for(int i = 0; i < 10; i++)
        {
            spawnEnemyRuler();
            yield return interval;
        }

        yield return new WaitForSeconds(20.0f);

        for(int i = 0; i < 10; i++)
        {
            spawnEnemyEraser();
            yield return interval;
        }

        yield return new WaitForSeconds(1.0f);

        for(int i = 0; i < 5; i++)
        {
            spawnEnemyPaper();
            yield return interval;
        }

        yield return new WaitForSeconds(1.0f);

        spawnEnemyStapler();
        yield return interval;
        spawnEnemyStapler();
        yield return interval;

        yield return new WaitForSeconds(20.0f);

        // If I use a for loop, coroutine stop DOES NOT stop the for loop
        // Tried fixing but this is the best for my sanity
        spawnEnemyPaper();              
        yield return new WaitForSeconds(1.0f);
        spawnEnemyEraser();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyPencil();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyPaper();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyEraser();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyPencil();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyPaper();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyEraser();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyPencil();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyPaper();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyEraser();
        yield return new WaitForSeconds(1.0f);
        spawnEnemyPencil();
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator spawnWave3()
    {
        for(int i = 0; i < 10; i++)
        {
            spawnEnemyPaper();
            yield return interval;
        }

        yield return new WaitForSeconds(2.0f);

        spawnEnemyRuler();
        yield return interval;
        spawnEnemyRuler();
        yield return interval;

        while(true)
        {
            spawnEnemyPencil();
            yield return new WaitForSeconds(5.0f);
            spawnEnemyPaper();
            yield return new WaitForSeconds(5.0f);
        }
    }
}
