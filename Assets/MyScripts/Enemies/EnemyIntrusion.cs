using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���̃X�N���v�g�͏o�� ("Map" > "IntrusionArea") �ɕt�^���܂��B
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
