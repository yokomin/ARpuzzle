using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    void OnTriggerEnter(Collider col){
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Goal"){
            gameManager.isGoal = true;
        } else if(col.gameObject.tag == "Enemy"){
            gameManager.isDead = true;
        }
    }

    void OnCollisionEnter(Collision col){
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Enemy") 
            gameManager.isDead = true;
    }
}
