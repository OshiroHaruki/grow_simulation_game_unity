using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    // buttonにつけるスクリプトなど。

    public void openGUI(GameObject gui){
        gui.SetActive(true);
    }
    public void closeGUI(GameObject gui){
        gui.SetActive(false);
    }
}
