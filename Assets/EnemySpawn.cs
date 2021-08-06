using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Level 1
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
        for(int a = 0; a < 5; a++){
            for(int i = 0; i < 5; i++){
                if(a < 2){
                    yield return new WaitForSeconds(spawnTime);
                    spawnEnemyPencil();
                }
                else{
                    yield return new WaitForSeconds(spawnTime + a);
                    spawnEnemyPencil();
                }
            }
            for(int i = 0; i < 2; i++){
                yield return new WaitForSeconds(spawnTime + 1.5f);
                spawnEnemyPaper();
            }
            for(int i = 0; i < 1; i++){
                yield return new WaitForSeconds(spawnTime);
                spawnEnemyEraser();
            }
        }
        while(true){
            for(int i = 0; i < 4; i++){
                yield return new WaitForSeconds(spawnTime + 2.0f);
                spawnEnemyPencil();
            }
            for(int i = 0; i < 2; i++){
            yield return new WaitForSeconds(spawnTime + 3.0f);
            spawnEnemyPaper();
            }
            for(int i = 0; i < 1; i++){
            yield return new WaitForSeconds(spawnTime + 4.0f);
            spawnEnemyEraser();
            }
        }
    }
}
