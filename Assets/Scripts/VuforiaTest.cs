using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuforiaTest : MonoBehaviour
{
    public GameObject ball;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            ResetBallPos();
        }
    }

    void ResetBallPos(){
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.transform.localPosition = new Vector3(3, 0, 0);
    }
}
