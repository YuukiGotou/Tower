using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���̃X�N���v�g�͏o�� ("Map" > "IntrusionArea") �ɕt�^���܂��B
public class EnemyIntrusion : MonoBehaviour
{
    private GameObject obj;
    private Sounds sounds;
    private void Start()
    {
        obj = GameObject.Find("Main Camera");
        sounds = obj.GetComponent<Sounds>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sounds.SoundPlay("Intrusion");
        Destroy(collision.gameObject);
    }
}
