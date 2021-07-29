using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefabs; 
    public GameObject catchEnemyPrefabs; 
    private float m_spawnTnterval = 1.0f;
    private float m_Timer = 0;

    void Start()
    {
        InvokeRepeating(nameof(catcherGenerate),m_Timer+1.0f,m_spawnTnterval);
        InvokeRepeating(nameof(evaderGenerate),m_Timer,m_spawnTnterval);
    }
    private void enemyGenerate(EnemyType enemyType){
        Vector3 spawnPosition = new Vector3(
            Random.Range(GameObject.Find("leftWall").transform.position.x+1f,GameObject.Find("rightWall").transform.position.x-1f),
            enemyPrefabs.transform.position.y,
            enemyPrefabs.transform.position.z
        );
        if(EnemyType.Catcher == enemyType ){
             Instantiate(catchEnemyPrefabs,
             spawnPosition,
             enemyPrefabs.transform.rotation);
        }else if(EnemyType.Evader == enemyType){
             Instantiate(enemyPrefabs,
             spawnPosition,
             enemyPrefabs.transform.rotation);
        }
    }  
    private void catcherGenerate(){
        enemyGenerate(EnemyType.Catcher);
    }private void evaderGenerate(){
        enemyGenerate(EnemyType.Evader);
    }
    // Update is called once per frame
    /*void Update()
    {
        m_Timer+=Time.deltaTime;
        if(m_Timer>= m_spawnTnterval){
             Instantiate(enemyPrefabs);
             m_Timer=0;
        }
    }*/
}
