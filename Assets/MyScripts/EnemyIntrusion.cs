using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// このスクリプトは出口 ("Map" > "IntrusionArea") に付与します。
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
