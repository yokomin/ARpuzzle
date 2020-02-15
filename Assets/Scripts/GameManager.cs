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
    [SerializeField] private GameObject[] resetObject;

    private int resetLength;
    private Rigidbody rigid;
    private Vector3[] resetPos;
    private Quaternion[] resetRot;
    private Rigidbody[] resetRigid;
    public bool isGoal{ set; get; }
    public bool isDead{ set; get; }
    
    private bool ballActive;

    // Start is called before the first frame update
    void Start()
    {
        resetLength = resetObject.Length;
        if(resetLength != 0){
            resetPos = new Vector3[resetLength];
            resetRot = new Quaternion[resetLength];
            resetRigid = new Rigidbody[resetLength];

            for(int i = 0; i < resetLength; i++){
                resetPos[i] = resetObject[i].transform.position;
                resetRot[i] = resetObject[i].transform.rotation;
                resetRigid[i] = resetObject[i].GetComponent<Rigidbody>();
            }
        }
        
        isGoal = false;
        rigid = ball.GetComponent<Rigidbody>();
        DeleteButton();
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
                if(!ballActive) {
                    Drop();
                }else if(ballActive){
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
        ShowButton();
    }

    private void ShowButton(){
        for(int i = 0; i < sceneName.Length; i++){
            buttons[i].SceneName = "Scenes/"+sceneName[i];
            buttons[i].setButtonName(sceneName[i]);
            buttons[i].gameObject.SetActive(true);
        }
        titleButton.SceneName = "Scenes/"+titleScene;
        titleButton.setButtonName("Back to Title");
        titleButton.gameObject.SetActive(true);
    }

    private void DeleteButton(){
        for(int i = 0; i < sceneName.Length; i++) buttons[i].gameObject.SetActive(false);
        titleButton.gameObject.SetActive(false);
    }

    private void Reset(){
        rigid.useGravity = false;
        rigid.isKinematic = true;
        ball.transform.position = startPoint.transform.position;

        if(resetLength != 0){
            for(int i = 0; i < resetLength; i++){
                resetObject[i].transform.position = resetPos[i];
                resetObject[i].transform.rotation = resetRot[i];
                resetRigid[i].useGravity = false;
                resetRigid[i].isKinematic = true;
            }
        }
        
        ballActive = false;
        isDead = false;
    }

    private void Drop(){
        rigid.useGravity = true;
        rigid.isKinematic = false;

        if(resetLength != 0){
            for(int i = 0; i < resetLength; i++){
                resetRigid[i].useGravity = true;
                resetRigid[i].isKinematic = false;
            }
        }

        ballActive = true;
    }
}
