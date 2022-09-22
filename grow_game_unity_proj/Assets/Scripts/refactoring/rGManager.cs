using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rGManager : MonoBehaviour
{
    public rEventManager eventManager;
    string status = "Stay";
    public GameObject StayUI;
    public GameObject StayUI_eventBox;
    public GameObject EventUI;
    public CharactorModel chara;
    bool eventFlag = false;
    public string[] eventTextFiles;
    int eventTextFileNum = 0;
    int numEvolution = 0;

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case "Stay":
                if(!StayUI.activeSelf){
                    StayUI.SetActive(true);
                }
                if((chara.checkLove()) && (!eventFlag)){
                    eventFlag = true;
                    StayUI_eventBox.SetActive(true);
                }
                break;
            case "Event":
                if(eventManager.tempFlag){
                    eventEnd();
                }
                break;
            case "Evolution":
                evolution();
                break;
            default:
                break;
        }
    }

    public void eventStart(){
        // buttonにつけてeventへ切り替える
        status = "Event";
        StayUI_eventBox.SetActive(false);
        StayUI.SetActive(false);
        eventFlag = false;
        EventUI.SetActive(true);
        eventManager.setEvent(0);
        eventTextFileNum++;
    }

    public void eventEnd(){
        status = "Stay";
        EventUI.SetActive(false);
        if(eventTextFileNum >= eventTextFiles.Length){
            // 次のイベントがない＝＞エンディング(現状だとタイトル)へ
            //SceneManager.LoadScene("title");
        }
    }

    public void evolution(){
        chara.evolution();// numEvolution);
        numEvolution++;
        status = "Stay";
    }

}
