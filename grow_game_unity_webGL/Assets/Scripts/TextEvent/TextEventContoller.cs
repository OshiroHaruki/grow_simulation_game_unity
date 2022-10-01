using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEventContoller : MonoBehaviour
{
    public TextEventModel textEventModel;

    public void click(){
        textEventModel.next();
    }
}
