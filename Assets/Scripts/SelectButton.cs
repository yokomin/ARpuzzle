using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    private string sceneName = "SceneName";
    [SerializeField] private Text buttonText;

    public void OnClick() {
        Debug.Log("Button click!");
        SceneManager.LoadScene(sceneName);
    }

    public void setSceneName(string name){
        sceneName = name;
    }

    public void setButtonName(string name){
        buttonText.text = name;
    }
}
