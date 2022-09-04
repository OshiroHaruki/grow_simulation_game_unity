using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI textComponent;
    string readText;
    string textFilePath;
    string[] messages;
    int textLine = 0;
    bool isEnd = false;

    void Update() {
        if (Input.GetMouseButtonDown(0)){
            next();
        }
    }

    public void initText(string fileName){
        textFilePath = Application.dataPath + "/Texts/" + fileName;
        readText = loadText(textFilePath);
        messages = readText.Split('\n');
        textLine = 0;
        setText(messages[textLine]);
    }

    private string loadText(string path){
        return File.ReadAllText(path);
    }
    private void setText(string mes){
        // Textオブジェクトにメッセージをセットする
        textComponent.text = mes.Replace(';', '\n');
    }
    private void next(){
        if (textLine < messages.Length-1){
            textLine++;
            setText(messages[textLine]);
        }else{
            // Debug.Log("処理終わり");
            isEnd = true;
        }
    }
    public bool getIsEnd(){
        return isEnd;
    }
    public void setIsEnd(bool flag){
        isEnd = flag;
    }
}
