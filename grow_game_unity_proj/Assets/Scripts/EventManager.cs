using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    int textLine;
    string[] texts;
    bool isEnd = false;
    bool wait = false;
    public TextMeshProUGUI textComponent;
    public AudioClip buttonSE;
    public AudioSource audioSource;

    public void setEvent(string fileName){
        // イベントを管理するテキストファイルを読み込み、1行ずつ分割する。
        string textFilePath = Application.dataPath + "/Texts/" + fileName;
        texts = File.ReadAllText(textFilePath).Split('\n');
        textLine = 0;
        isEnd = false;
        next();
    }

    public void click(){
        // テキストボックスにつければお手軽.
        if(!wait){
            audioSource.PlayOneShot(buttonSE);
            next();
        } 
    }

    public void next(){
        if (textLine < texts.Length){
            string target = texts[textLine];
            if(target[0].Equals('$')){
                // 選択肢の発生.
                // 未定→ setChoice(target);
            }else{
                // 通常のテキストを描画.
                // 未実装→ setText(); 
                textComponent.text = target.Replace(';', '\n');
            }
            textLine++;
        } else {
            isEnd = true;
        }
    }

    private void setText(string mes){
        // Textオブジェクトにメッセージをセットする
        textComponent.text = mes.Replace(';', '\n');
    }

    public void setChoice(string t){
        // '$'区切りでテキストを書いておき、それを分割して選択肢とする。
        string[] answers = t.Split('$');
        // ans1 = answers[0] みたいな感じ。ans1には、eventUIのボックス的なのを格納しておけば、スムーズかも。
        // ans2, ans3は上記同様。
        // eventUIをTrueにする。
        wait = true; // 待機状態へ。
    }

    public void choice(int number){
        // 選択肢に、当然のように条件分岐つけようとしてるけど、
        // どうやってやるかは未定...
    }

    public bool isEndEvent(){
        return isEnd;
    }
}
