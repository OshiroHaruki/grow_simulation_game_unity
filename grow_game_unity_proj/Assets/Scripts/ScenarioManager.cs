using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScenarioManager : MonoBehaviour
{
    TextManager tManager;
    GameObject textBox;
    string[] textFiles = new string[] {"mes1.txt", "mes2.txt", "mes3.txt"};
    int textFileNum = 0;
    string[] scenarios;
    int scenarioLine = 0;
    string scenarioFilePath;
    string status = "Init"; // Init, Wait, Text, Event, Evaluation, Feed, 

    void Start(){
        // textBox = GameObject.Find("TextArea");
        // tManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        initScenario("scenario1.txt");
    }

/*
    void Update(){
        if(tManager.getIsEnd()){
            next();
        }
    }
*/

    public void initScenario(string fileName){
        scenarioFilePath = Application.dataPath + "/Scenarios/" + fileName;
        string readScenario = loadScenario(scenarioFilePath);
        scenarios = readScenario.Split('\n');
        scenarioLine = 0;
        //next();
    }

    private string loadScenario(string path){
        return File.ReadAllText(path);
    }

    private void next(){
        if (scenarioLine < scenarios.Length){
            if (scenarios[scenarioLine][0].Equals('/')){
                tManager.initText(scenarios[scenarioLine].Substring(1));
                tManager.setIsEnd(false);
            }
        }else{
            Debug.Log("おしまい");
        }
        scenarioLine++;
    }

    public string nextScenario(){
        string s = scenarios[scenarioLine];
        scenarioLine++;
        return s;
    }
}
