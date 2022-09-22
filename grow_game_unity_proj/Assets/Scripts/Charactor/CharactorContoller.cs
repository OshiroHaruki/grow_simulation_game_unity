using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorContoller : MonoBehaviour
{
    public CharactorModel charactorModel;
    public void feed(){
        charactorModel.feed();
        // print(charactorModel.love);
    }
}
