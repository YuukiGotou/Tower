using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    private GameObject unitmanager;
    private UnitManager ui_clicked;
    private int Number;
    RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        ui_clicked = unitmanager.GetComponent<UnitManager>();
        
    }

    public void InputData(int i, GameObject unitmanager)
    {
        this.unitmanager = unitmanager;
        Number = i;
        rect.localPosition += new Vector3(-210 + (80 * Number), -150, 0);
        this.GetComponent<Image>().sprite = unitmanager.GetComponent<SpriteRenderer>().sprite;
    }

    // Start is called before the first frame update
    public void OnClick()
    {
        ui_clicked.UI_Clicked(Number, transform.position);
        
    }
}
