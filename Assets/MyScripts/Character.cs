using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected float speed; // 1�����̃t���[����
    private float timer; // �t���[���J�E���g�p
    protected bool flying; // �󔻒�
    protected bool mistbody; // ���F����
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
        Debug.Log("�I�[�o�[���C�h���Ă��������B");
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
