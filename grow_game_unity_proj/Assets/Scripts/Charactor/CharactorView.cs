using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CharactorView : MonoBehaviour
{
    public AudioClip evolutionSE;
    public AudioSource audioSource;
    Material material;

    void Start(){
        material = gameObject.GetComponent<Renderer>().material;
    }

    public void evolutionView(Texture texture){
        setCharactorImage(texture);
        StartCoroutine("flashing");
        soundEfect();
    }

    private void setCharactorImage(Texture texture){
        material.SetTexture("_MainTex", texture);
    }

    private void soundEfect(){
        audioSource.PlayOneShot(evolutionSE);
    }

    private IEnumerator flashing(){
        // 無理やり点滅させる。
        // animationへ移行したいなぁ(未定)
        int fNum = 5; //点滅回数
        float fDis = 0.1f; //点滅する間隔
        MeshRenderer m = this.gameObject.GetComponent<MeshRenderer>();
        for(int i = 0; i < fNum; i++){
            m.enabled = false;
            yield return new WaitForSeconds(fDis);
            m.enabled = true;
            yield return new WaitForSeconds(fDis);
        }
        yield return null;
    }
}
