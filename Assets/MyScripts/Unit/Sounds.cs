using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip death; // �����X�^�[���S�pSE
    public AudioClip intrusion; // �����X�^�[�ɐN�����ꂽSE

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void SoundPlay(string s)
    {
        switch (s)
        {
            case "Death":
                audiosource.PlayOneShot(death);
                break;
            case "Intrusion":
                audiosource.PlayOneShot(intrusion);
                break;
        }
    }
}
