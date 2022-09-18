using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    public int loveAmount = 0; // 親愛度
    public int needLove = 2; // 進化に必要なlove
    // いったんpass public string[] imageMaterialNames; // キャラ画像を適用したマテリアル名
    // いったんpass public string tMaterialName = "animal_alpaca_huacaya.png"; // マテリアル名を指定して、それに変更できるかの確認用.
    public Material material;
    public Texture[] images;
    public AudioClip evolutionSE;
    public AudioSource audioSource;

    void Start(){
        material = gameObject.GetComponent<Renderer>().material;
        // 画像が切り替わるかの確認-> evolution();
    }

    public bool checkLove(){
        // 親愛度が、進化に必要な分あるかを判定する。
        return (loveAmount >= needLove);
    }

    public void feed(){
        // 餌を与え、親愛度を上げる
        addLove(1); //とりあえず1
    }

    public void stroke(){
        // 撫でる(clickする)ことで、信頼度を上げる.
        addLove(1); // とりあえず1
    }

    public void evolution(int nextImageNum = 0){
        loveAmount = 0; //リセット
        needLove = 2;
        setCharaImage(images[nextImageNum]);
        audioSource.PlayOneShot(evolutionSE);
        StartCoroutine("flashing"); // 点滅して変化感を演出.
    }

    private void addLove(int l){
        loveAmount += l;
    }

    private void setCharaImage(Texture t){
        material.SetTexture("_MainTex", t);
    }

    private IEnumerator flashing(){
        // evolutionはこの関数にした方が良いかも.
        for (int a = 0; a < 5 ; a++){
            // spriteのcolorのalpha値をsin()で更新 or MeshRendererをenable-ableで切り替え
            // 今回はより手軽なMeshRendererをいじる方。
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            // yield return WaitForSecond(0.1)とか。
            yield return new WaitForSeconds(0.1f);
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
