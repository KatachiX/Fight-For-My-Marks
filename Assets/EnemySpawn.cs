using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPencilPrefab;
    public GameObject enemyPaperPrefab;
    public GameObject enemyEraserPrefab;
    public float spawnTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnWave());
    }

    private void spawnEnemyPencil(){
        GameObject pencil = Instantiate(enemyPencilPrefab) as GameObject;
        pencil.transform.position = new Vector2(8.69f, -3.5f);
    }
    private void spawnEnemyPaper(){
        GameObject pencil = Instantiate(enemyPaperPrefab) as GameObject;
        pencil.transform.position = new Vector2(8.69f, -3.5f);
    }
    private void spawnEnemyEraser(){
        GameObject pencil = Instantiate(enemyEraserPrefab) as GameObject;
        pencil.transform.position = new Vector2(8.69f, -3.5f);
    }

    IEnumerator spawnWave(){
        for(int i = 0; i < 3; i++){
            yield return new WaitForSeconds(spawnTime);
            spawnEnemyPencil();
        }
        for(int i = 0; i < 2; i++){
            yield return new WaitForSeconds(spawnTime);
            spawnEnemyPaper();
        }
        for(int i = 0; i < 1; i++){
            yield return new WaitForSeconds(spawnTime);
            spawnEnemyEraser();
        }
    }
}
