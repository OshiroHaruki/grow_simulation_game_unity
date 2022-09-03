using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    TextManager tManager;
    GameObject textBox;
    string[] textFiles = new string[] {"mes1.txt", "mes2.txt", "mes3.txt"};
    int textFileNum = 0;

    void Start(){
        textBox = GameObject.Find("TextArea");
        tManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        tManager.setScenario(textFiles[textFileNum]);
    }

    void Update(){
        if(tManager.getIsEnd()){
            textFileNum++;
            if (textFileNum < textFiles.Length){
                tManager.setScenario(textFiles[textFileNum]);
                tManager.setIsEnd(false);
            }else{
                Debug.Log("おしまい");
            }
        }
    }
}
