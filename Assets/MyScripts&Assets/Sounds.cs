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

    public void SoundPlay(AudioClip audio_name)
    {
        audiosource.PlayOneShot(audio_name);
    }
}
