using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public EventManager eventManager;
    public GameObject StayUI;
    public GameObject StayUI_eventBox;
    public GameObject EventUI;
    public CharactorModel chara;
    public CharactorView charactorView;
    int scenarioNum = 0; // Stay→Eventを1セットこなす＝scenario１個分、とする.
    public Button eventStartButton;

    void Start(){
        charactorView.startMovingAnimation(); // アニメーション開始.
        mainLoop();
    }

    public async UniTask mainLoop(){
        // ゲームループ.
        var asyncEventHandler = eventStartButton.onClick.GetAsyncEventHandler(CancellationToken.None);
        int i = 0;
        while(i < 5){
            // eventの数分ループすればよい。最終的にStay画面が永続する状態にする.
            // 待機状態(餌を与えるなどの状態)
            await UniTask.WaitUntil(() => chara.checkLove());
            StayUI_eventBox.SetActive(true);
            // イベント待機状態(イベント開始前)
            // buttonのEventSystemをUniTaskで検知できるらしい。もっと早く知りたかった...
            await asyncEventHandler.OnInvokeAsync();
            eventStart(i);
            await UniTask.WaitUntil(() => eventManager.eventEndFlag);
            eventEnd();
            i++;
        }
    }

    public void eventStart(int n){
        StayUI_eventBox.SetActive(false);
        StayUI.SetActive(false);
        EventUI.SetActive(true);
        eventManager.setEvent(n);
        charactorView.stopMovingAnimation();// アニメーションを止める.
    }

    private void eventEnd(){
        EventUI.SetActive(false);
        StayUI.SetActive(true);
        chara.resetLove();
        charactorView.startMovingAnimation(); // アニメーションの再開
    }

}
