using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType{
    Catcher,
    Evader
}
public class EnemyController : MonoBehaviour
{
    public Stats stats;
    public EnemyType enemyType;
    private float m_tressholdZ = -20.0f;
    private Transform m_playerTransform;
    private playerController m_pc;
   /* void Awake(){
        //prologue
       /* Stats stats = GetComponent<Stats>();
        Debug.Log("enemy hp :"+stats.health);
        GameObject player = GameObject.Find("player");
        Debug.Log("Enemy Phase:=> Your Player hp : "+player.GetComponent<Stats>().health);
        Debug.Log("Enemy Hp:=>"+stats.health);
    }*/
    void Start(){
        m_pc = GameObject
              .Find("Player")
              .GetComponent<playerController>();
    }
    void Update(){
        transform.position = new Vector3(
        transform.position.x,
        transform.position.y,
        transform.position.z - 1.0f * stats.velocity * Time.deltaTime);
        if(Vector3.Distance(m_pc.transform.position,transform.position) < 1.0f){
            if(enemyType == EnemyType.Evader){
                m_pc.recieveDamage();
            }
             Destroy(gameObject);
        
        }else if(m_pc.transform.position.z - transform.position.z >=5.0f && enemyType == EnemyType.Catcher){
            m_pc.recieveDamage();
            Destroy(gameObject);
        }
        else if(transform.position.z <= m_tressholdZ){
            Destroy(gameObject);
        }
    }
  
 
}
