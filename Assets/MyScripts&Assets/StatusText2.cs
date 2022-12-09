using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusText2 : MonoBehaviour
{
    [SerializeField]
    private GameObject textObject;
    private TextMeshProUGUI writeText;
    private int maxWave = 0;
    private int wave = 0;

    private void Start()
    {
        writeText = textObject.GetComponent<TextMeshProUGUI>();
    }
    public void SetWave(int n1, int n2)
    {
        maxWave = n1;
        wave = n2;
    }
    public void SetNowWave(int n)
    {
        wave = n;
    }

    void FixedUpdate()
    {
        writeText.text = wave + "/" + maxWave;
    }


}