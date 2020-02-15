using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    //[SerializeField] private GameObject grave;
    private GameObject graveInstance;

    void Start(){
        //graveInstance = Instantiate(grave, new Vector3(-20f, 15f, -0.081f), Quaternion.identity);
    }

    void OnTriggerEnter(Collider col){
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Goal"){
            gameManager.isGoal = true;
        } else if(col.gameObject.tag == "Enemy"){
            Dead();
        }
    }

    void OnCollisionEnter(Collision col){
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Enemy") {
            Dead();
        }
    }

    void Dead(){
        //graveInstance.transform.position = this.transform.position;
        gameManager.isDead = true;
    }
}
