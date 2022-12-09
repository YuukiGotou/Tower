using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip death; // モンスター死亡用SE
    public AudioClip intrusion; // モンスターに侵入されたSE

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void SoundPlay(AudioClip audio_name)
    {
        audiosource.PlayOneShot(audio_name);
    }
}
