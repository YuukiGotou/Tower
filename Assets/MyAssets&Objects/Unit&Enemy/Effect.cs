using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private int timer = 0;
    [SerializeField]
    private int playtime; // Ä¶‚·‚éŠÔ
    void Update()
    {
        timer++;
        if(playtime <= timer)
        {
            Destroy(gameObject);
        }
    }
}
