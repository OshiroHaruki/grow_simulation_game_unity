using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextEventView : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public AudioClip buttonSE;
    public AudioSource audioSource;

    public void view(string text){
        playClickSE();
        showText(text);
    }

    private void showText(string text){
        // TextMeshProUGUIにtextをセットする.
        textComponent.text = text;
    }

    private void playClickSE(){
        audioSource.PlayOneShot(buttonSE);
    }
}
