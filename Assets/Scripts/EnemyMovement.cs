using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float upLimit = 10.5f;
    [SerializeField] private float downLimit = -10.5f;
    [SerializeField] private float speed = 1f;
    private bool up = false;

    // Update is called once per frame
    void Update()
    {
        if(up && transform.position.y >= upLimit){
            up = false;
        } else if(!up && transform.position.y <= downLimit){
            up = true;
        }

        if(up){
            transform.Translate(0,speed * Time.deltaTime,0);
            if(transform.position.y > upLimit){
                transform.position = new Vector3(transform.position.x, upLimit, transform.position.z);
            }
        }else{
            transform.Translate(0,-speed * Time.deltaTime,0);
            if(transform.position.y < downLimit){
                transform.position = new Vector3(transform.position.x, downLimit, transform.position.z);
            }
        }
    }
}
