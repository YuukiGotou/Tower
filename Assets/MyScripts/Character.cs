using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected float speed; // 1周期のフレーム数
    private float timer; // フレームカウント用
    protected bool flying; // 空判定
    protected bool mistbody; // 視認判定
    private GameObject obj;
    private Sounds sounds;
    
    protected virtual void Start()
    {
        timer = 0;
        obj = GameObject.Find("Main Camera");
        sounds = obj.GetComponent<Sounds>();
    }

    protected virtual void Update()
    {
        timer++;
    }

    protected virtual void FixedUpdate()
    {
        if (timer >= speed)
        {
            LoopAction();
            timer = 0;
        }
    }
    protected virtual void LoopAction()
    {
        Debug.Log("オーバーライドしてください。");
    }

    protected float TimeCount()
    {
        return timer / speed;
    }
    protected void SelectSound(string s)
    {
        sounds.SoundPlay(s);
    }
}
