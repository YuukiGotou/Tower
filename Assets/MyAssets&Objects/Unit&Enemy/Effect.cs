using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private int timer = 0;
    [SerializeField]
    private int playtime; // 再生する時間
    void Update()
    {
        timer++;
        if(playtime <= timer)
        {
            Destroy(gameObject);
        }
    }
}
