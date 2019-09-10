using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] private string[] sceneName;
    [SerializeField] private SelectButton[] buttons;

    private 

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sceneName.Length; i++){
            buttons[i].SceneName = "Scenes/"+sceneName[i];
            buttons[i].setButtonName(sceneName[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
