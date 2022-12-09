using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    [SerializeField]
    private GameObject pressText;
    [SerializeField]
    private GameObject canvas;
    private Transform canvas_transform;

    private bool check = false;
    private int time = 0;

    private void Start()
    {
        canvas_transform = canvas.transform;
    }
    void Update()
    {
        time++;
        if (!check && time > 600)
        {
            Instantiate(pressText, canvas_transform);
            check = true;
        }
    }
}
