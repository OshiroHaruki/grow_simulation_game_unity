using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class TextEventModel : MonoBehaviour
{
    string[] texts;
    int textLine;
    bool isEnd;
    public TextEventView textEventView;

    public async UniTask textEventExec(string[] t){
        setTextEvent(t);
        await UniTask.WaitUntil(() => isEnd);
    }

    private void setTextEvent(string[] t){
        // 初期化&最初の一文を表示.
        texts = t;
        textLine = 0;
        isEnd = false;
        setText();
    }

    private void setText(){
        string text = texts[textLine].Replace(';', '\n');
        textEventView.view(text);
    }

    public void next(){
        textLine++;
        if(textLine < texts.Length){
            setText();
        }else{
            isEnd = true;
        }
    }

}
