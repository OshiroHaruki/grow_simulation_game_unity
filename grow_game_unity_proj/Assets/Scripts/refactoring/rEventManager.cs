using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Cysharp.Threading.Tasks;
using System;

public class rEventManager : MonoBehaviour
{
    public TextEventModel textEvent;
    public CharactorModel chara;
    public string[] textFiles;
    int textLineNum;
    string[] readTextLines;
    public bool tempFlag = false;

    public void setEvent(int eventNum){
        // GameManager→この関数へEventの内容が書かれたテキストの番号を代入して実行する.
        // textファイルを読み込む
        string s = Application.dataPath + "/Texts/" + "test1.txt";//textFiles[eventNum];
        readTextLines = File.ReadAllText(s).Split('\n');
        // 値の初期化.
        textLineNum = 0;
        // イベント開始
        eventExec();
    }

    private async UniTask eventExec(){
        // 読み込んだTextFileを1行ずつ処理していく.
        while (textLineNum < readTextLines.Length){
            if(readTextLines[textLineNum].Length == 0){
                // 0文字(空行)ならreadTextLines++;してcontinue
                textLineNum++;
                continue;
            }
            if(readTextLines[textLineNum][0].Equals('!')){
                // !で囲んだ範囲がtextEvent
                // textEventの範囲の文字列を切り取り、textEventを始める.
                string[] textEventStrings = cutTextEventStrings();
                // textEventが終わるまでawaitする.
                await textEvent.textEventExec(textEventStrings);

            }else if(readTextLines[textLineNum][0].Equals('&')){
                // &で始める部分がevolutionEvent.
                await chara.evolution();
            }
            else{
                // 以下の処理を実装予定
                    // $で囲んだ範囲をchoiceEvent/
            }
            textLineNum++;
        }
        tempFlag = true;
    }

    private string[] cutTextEventStrings(){
        // textEventの範囲の文字列を切り取り、改行で分割してstring配列を返す.
        textLineNum++;
        int startNum = textLineNum;
        while(textLineNum < readTextLines.Length){
            // テキストファイルの範囲内で探索.
            if(readTextLines[textLineNum].Length == 0){
                // 0文字だったら次の行へ.
                textLineNum++;
                continue;
            }
            if(readTextLines[textLineNum][0].Equals('!')){
                break;
            }
            textLineNum++;
        }

        int sub = textLineNum - startNum;
        string[] result = new string[sub];
        Array.Copy(readTextLines, startNum, result, 0, sub);
        return result;
    }
}
