using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUnit : MonoBehaviour
{
    private GameObject obj;
    private Vector3 target;
    private void Start()
    {
        obj = (GameObject)Resources.Load(transform.parent.name);
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(collision.gameObject.tag == "CanPutting")
            {
                
            }
        }
    }
}
