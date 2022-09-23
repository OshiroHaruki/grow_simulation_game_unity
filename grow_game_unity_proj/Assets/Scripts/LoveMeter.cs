using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class LoveMeter : MonoBehaviour
{
    public CharactorModel chara;
    public Image meter;
    int _prevLove;

    void Start() {
        _prevLove = chara.love;
        meter.fillAmount = 0f;
        loveMeterUpdate();
    }

    async UniTask loveMeterUpdate(){
        while(true){
            await UniTask.WaitUntil(() => chara.love != _prevLove);
            _prevLove = chara.love;
            int n = chara.love;
            if(n > chara.needLove){
                n = chara.needLove;
            }
            print(n);
            print(chara.needLove);
            float viewPersent = 1.0f * n / chara.needLove;
            meter.fillAmount = viewPersent;
            print(viewPersent);
        }
    }

}
