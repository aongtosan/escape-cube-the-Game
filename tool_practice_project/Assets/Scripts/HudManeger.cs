using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public Text health;
    public void  updateHealthPoint(float health){
        this.health.text = "HealthPoint : "+health;
    }
    void Update(){

    }
}
