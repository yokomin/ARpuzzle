using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private string stageName;
    [SerializeField] private Text text;
    [SerializeField] private string titleScene = "TitleScene";
    [SerializeField] private SelectButton titleButton;
    [SerializeField] private string[] sceneName;
    [SerializeField] private SelectButton[] buttons;
    private Rigidbody rigid;
    public bool isGoal{ set; get; }
    public bool isDead{ set; get; }
    
    private enum GameState{
        ballStop, 
        ballActive
    }

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        isGoal = false;
        rigid = ball.GetComponent<Rigidbody>();
        Reset();
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop(){
        text.text = stageName;
        yield return new WaitForSeconds(2.0f);
        text.text = "Start!";
        yield return new WaitForSeconds(2.0f);
        text.text = "";

        while(true){
            if(ball.transform.position.x < -20 || ball.transform.position.x > 20 
                || ball.transform.position.y < -15 || ball.transform.position.y > 15){
                isDead = true;
            }

            if(isGoal){
                StageClear();
                break;
            }

            if(isDead) 
                Reset();

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

        text.text = stageName + " Clear!";
        for(int i = 0; i < sceneName.Length; i++){
            buttons[i].SceneName = "Scenes/"+sceneName[i];
            buttons[i].setButtonName(sceneName[i]);
            buttons[i].gameObject.SetActive(true);
        }
        titleButton.SceneName = "Scenes/"+titleScene;
        titleButton.setButtonName("タイトルに戻る");
        titleButton.gameObject.SetActive(true);
    }

    private void Reset(){
        rigid.useGravity = false;
        rigid.isKinematic = true;
        ball.transform.position = startPoint.transform.position;
        gameState = GameState.ballStop;
        isDead = false;
        Debug.Log("Reset:" + gameState);
    }

    private void BallDrop(){
        rigid.useGravity = true;
        rigid.isKinematic = false;
        gameState = GameState.ballActive;
        Debug.Log("Drop:" + gameState);
    }
}
