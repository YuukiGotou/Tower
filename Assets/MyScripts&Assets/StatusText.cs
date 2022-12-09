using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusText : MonoBehaviour
{
    [SerializeField]
    private GameObject textObject;
    private TextMeshProUGUI writeText;
    private int showstatus = 0;

    private void Start()
    {
        writeText = textObject.GetComponent<TextMeshProUGUI>();
    }

    public void SetStatus(int n)
    {
        showstatus = n;
    }

    void FixedUpdate()
    {
        writeText.text = "" + showstatus;
    }


}