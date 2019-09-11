using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{

    public string SceneName { set; get; }

    [SerializeField] private Text buttonText;

    public void OnClick() {
        SceneManager.LoadScene(SceneName);
    }

    public void setButtonName(string name){
        buttonText.text = name;
    }
}
