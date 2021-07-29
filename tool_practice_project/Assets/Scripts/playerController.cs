using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
   public Stats stats;
   public Transform leftWall;
   public Transform rightWall;

   public HudManeger hudManeger;
  void Awake(){
    //prologue
    /*Stats stats = GetComponent<Stats>();
    Debug.Log("player hp :"+stats.health);
    GameObject enemy = GameObject.Find("enemy");
    Debug.Log("player Phase:=> Your Enemy hp : "+enemy.GetComponent<Stats>().health);
    Debug.Log("Player Hp:=>"+stats.health);*/
    stats = GetComponent<Stats>();
    hudManeger.updateHealthPoint(stats.health);
  }
  void Update(){
    if(stats.health<=0){
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    float horizontalXposition =  transform.position.x+horizontalInput * stats.velocity * Time.deltaTime;
    float verticalZposition =  transform.position.z+verticalInput * stats.velocity * Time.deltaTime;
    if(horizontalXposition-0.5<= leftWall.position.x +0.5f) return;
    if(horizontalXposition+0.5>= rightWall.position.x -0.5f) return;
    transform.position = new Vector3(
      transform.position.x+horizontalInput * stats.velocity * Time.deltaTime
      ,(float)0.5,
      transform.position.z+verticalInput * stats.velocity * Time.deltaTime);
  }
  public void recieveDamage(){
    stats.decreaseHealth();
    hudManeger.updateHealthPoint(stats.health);
    Debug.Log("hit");
  }
  
}
