using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// このスクリプトは出口 ("Map" > "IntrusionArea") に付与します。
public class EnemyIntrusion : MonoBehaviour
{
    [SerializeField]
    private GameObject maincamera;

    [SerializeField]
    private GameObject enemymanager;

    private Sounds sounds;
    private EnemyManager intrusion;
    
    private void Start()
    {
        sounds = maincamera.GetComponent<Sounds>();
        intrusion = enemymanager.GetComponent<EnemyManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sounds.SoundPlay("Intrusion");
        intrusion.DisappearEnemy();
        Destroy(collision.gameObject);
    }
}
