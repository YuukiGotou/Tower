using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    private GameObject unitmanager;
    private int unitnumber; // "UnitManager"からオブジェクトを参照

    public void InputData(GameObject unitmanager, int unitnumber) // オブジェクトの登録
    {
        this.unitmanager = unitmanager;
        this.unitnumber = unitnumber;
    }

    private void OnMouseOver()
    {
        // データウィンドウの表示
        UnitManager showwindow = unitmanager.GetComponent<UnitManager>();
    }

    public void OnClick() // クリック時の処理
    {
        Sprite sprite = GetComponent<Image>().sprite;
        unitmanager.GetComponent<UnitManager>().UI_Clicked(sprite, transform.position, unitnumber);
    }
}