using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;
    public float velocity;
    public void decreaseHealth(){
        health = health-1.0f;
    }
}
