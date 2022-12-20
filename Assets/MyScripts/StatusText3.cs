using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusText3 : MonoBehaviour
{
    [SerializeField]
    private GameObject textObject;
    private TextMeshProUGUI writeText;
    private int ATK;
    private int Cost;
    private int Speed;

    private void Start()
    {
        writeText = textObject.GetComponent<TextMeshProUGUI>();
    }
    public void ShowStatus(int n1, int n2, int n3)
    {
        ATK = n1;
        Cost = n2;
        Speed = n3;
    }

    void FixedUpdate()
    {
        writeText.text = "ATK:" + ATK + "\nCost:" + Cost + "\nSpeed:" + Speed;
    }


}