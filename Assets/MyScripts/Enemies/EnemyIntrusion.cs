using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// このスクリプトは出口 ("Map" > "IntrusionArea") に付与します。
public class EnemyIntrusion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Intrusion();
            Destroy(collision.gameObject);
        }
    }
}
