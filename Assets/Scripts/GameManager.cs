using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject goalPoint;
    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = ball.GetComponent<Rigidbody>();
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame(){
        rigid.useGravity = false;
        rigid.isKinematic = true;
        ball.transform.position = startPoint.transform.position;
        while(!Input.GetMouseButtonDown(0)) yield return null;
        rigid.useGravity = true;
        rigid.isKinematic = false;
        yield return StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop(){
        while(true){
            if(ball.transform.position.x < -20 || ball.transform.position.x > 20 
                || ball.transform.position.y < -15 || ball.transform.position.y > 15){
                Debug.Log("Reset");
                StartCoroutine(StartGame());
                break;
            }

            if((ball.transform.position - goalPoint.transform.position).sqrMagnitude < 2){
                StageClear();
                break;
            }
            yield return null;
        }
    }

    private void StageClear(){
        rigid.useGravity = false;
        rigid.isKinematic = true;
        Debug.Log("Clear");
    }
}
