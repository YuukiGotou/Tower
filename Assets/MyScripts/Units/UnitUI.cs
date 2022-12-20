using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitUI : MonoBehaviour
{
    private GameObject unitmanager;
    private UnitManager um_method;
    private int unitnumber; // "UnitManager"からオブジェクトを参照
    private int ATK;
    private int Cost;
    private int Speed;
    private GameObject Window;
    private GameObject obj;
    private EventTrigger trigger;
    private Transform canvas;

    public void InputData(GameObject unitmanager, GameObject window,int unitnumber,Transform canvas) // オブジェクトの登録
    {
        this.canvas = canvas;
        Window = window;
        this.unitmanager = unitmanager;
        this.unitnumber = unitnumber;
        um_method = unitmanager.GetComponent<UnitManager>();
        ATK = um_method.GetAtk(unitnumber);
        Cost = um_method.GetCost(unitnumber);
        Speed = um_method.GetSpeed(unitnumber);

        trigger = GetComponent<EventTrigger>();
        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        trigger.triggers.Add(entry);
        var exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        trigger.triggers.Add(exit);
    }

    public void PointerEnter()
    {
        // データウィンドウの表示
        Vector3 vec = gameObject.transform.position;
        vec += new Vector3(0, 2.0f, 0);
        obj = Instantiate(Window, vec, Quaternion.identity, canvas);
        obj.GetComponent<StatusText3>().ShowStatus(ATK, Cost, Speed);
    }
    public void PointerExit()
    {
        Destroy(obj);
    }


    public void OnClick() // クリック時の処理
    {
        Sprite sprite = GetComponent<Image>().sprite;
        unitmanager.GetComponent<UnitManager>().UI_Clicked(sprite, transform.position, unitnumber);
    }
}