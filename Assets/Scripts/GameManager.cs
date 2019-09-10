using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject goalPoint;
    private Rigidbody rigid;

    private enum GameState{
        ballStop, 
        ballActive
    }

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        rigid = ball.GetComponent<Rigidbody>();
        Reset();
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop(){
        while(true){
            if(ball.transform.position.x < -20 || ball.transform.position.x > 20 
                || ball.transform.position.y < -15 || ball.transform.position.y > 15){
                Reset();
            }

            if((ball.transform.position - goalPoint.transform.position).sqrMagnitude < 2){
                StageClear();
                break;
            }

            if(Input.GetMouseButtonDown(0)) {
                Debug.Log("mouse");
                if(gameState == GameState.ballStop) {
                    BallDrop();
                }else if(gameState == GameState.ballActive){
                    Reset();
                }
            }

            yield return null;
        }
        yield break;
    }

    private void StageClear(){
        rigid.useGravity = false;
        rigid.isKinematic = true;
        Debug.Log("Clear");
    }

    private void Reset(){
        rigid.useGravity = false;
        rigid.isKinematic = true;
        ball.transform.position = startPoint.transform.position;
        gameState = GameState.ballStop;
        Debug.Log("Reset:" + gameState);
    }

    private void BallDrop(){
        rigid.useGravity = true;
        rigid.isKinematic = false;
        gameState = GameState.ballActive;
        Debug.Log("Drop:" + gameState);
    }
}
