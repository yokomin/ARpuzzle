using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject goalPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame(){
        ball.transform.position = startPoint.transform.position;
        ball.GetComponent<Rigidbody>().useGravity = false;
        while(!Input.GetButtonDown("Submit")) yield return null;
        ball.GetComponent<Rigidbody>().useGravity = true;
        yield return StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop(){
        while(true){
            if(ball.transform.position.x < -20 || ball.transform.position.x > 20 
                || ball.transform.position.z < -15 || ball.transform.position.z > 15){
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
        Debug.Log("Clear");
    }
}
