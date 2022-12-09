using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
void Update()
    {
        transform.position += new Vector3(0, 0.001f, 0);
        if(transform.position.y >= 12.0f)
        {
            transform.position += new Vector3(0, -24.0f, 0);
        }
    }
}
