using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private int timer = 0;
    [SerializeField]
    private int playtime; // �Đ����鎞��
    void Update()
    {
        timer++;
        if(playtime <= timer)
        {
            Destroy(gameObject);
        }
    }
}
