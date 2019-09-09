using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame(){
        while(true){
            if(Input.GetButtonDown("Submit")){
                break;
            }
        }
        yield return StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop(){
        while(true){
            if(ball.transform.position.x < -20 || ball.transform.position.x > 20 || ball.transform.position.z < -15 || ball.transform.position.z > 15){
                StartCoroutine(StartGame());
            }

            if(Mathf.Abs(ball.transform.position.x - goal.transform.position.x) < 1){
                if(Mathf.Abs(ball.transform.position.z - goal.transform.position.z) < 1){
                    StageClear();
                    break;
                }
            }
        }
        yield return null;
    }

    private void StageClear(){
        Debug.Log("Clear");
    }
}
