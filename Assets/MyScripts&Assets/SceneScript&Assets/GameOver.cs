using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Vector3 ver = Vector3.zero;
    private int time = 0;
    private int count = 0;
    private bool check = false;
    [SerializeField]
    private GameObject pressText;
    [SerializeField]
    private GameObject canvas;
    private Transform canvas_transform;

    private void Start()
    {
        canvas_transform = canvas.transform;
    }
    void Update()
    {
        time++;
        count++;
        if (count % 2 == 0)
        {
            if (time < 180)
            {
                if (transform.position != Vector3.zero)
                {
                    transform.position = Vector3.zero;
                }
                else
                {
                    float rnd1 = Random.Range(-2.0f, 2.0f);
                    float rnd2 = Random.Range(-2.0f, 2.0f);
                    transform.position = new Vector3(rnd1, rnd2, 0);
                }
            }
            else
            {
                transform.position = Vector3.zero;
            }
            count = 0;
        }

        if(!check && time > 300)
        {
            Instantiate(pressText, canvas_transform);
            check = true;
        }
    }
}
