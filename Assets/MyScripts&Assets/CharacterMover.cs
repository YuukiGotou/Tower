using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMover : MonoBehaviour
{
    [SerializeField]
    protected float speed; // クールタイムの設定
    protected float timer = 0;

    protected GameManager gm_method;
    protected GameObject sliderUI;
    protected SliderUI sUI_method;

    protected virtual void Update()
    {
        timer++;
    }

    protected virtual void FixedUpdate()
    {
        if(timer >= speed)
        {
            timer = speed;
            LoopAction();
            timer = 0;
        }
    }

    protected virtual void LoopAction()
    {
        // 1クールタイム毎に行う行動をオーバーライドして使用する。
    }

    protected void moneyModification(int money)
    {
        gm_method.MoneyModification(money);
    }

    protected void SelectSound(AudioClip audio_name)
    {
        gm_method.PlaySound(audio_name);
    }
}
