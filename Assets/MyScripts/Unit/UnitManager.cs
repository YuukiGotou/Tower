using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] units; // ユニットの登録
    private GameObject OnMouseUnit; // マウスに追従するユニット

    [SerializeField]
    private GameObject unitUI; // ユニットのUI用(空のButton UIを入れる)
    private GameObject unitUISet;

    [SerializeField]
    private GameObject redsquare; // 強調表示オブジェクト実装
    private GameObject obj;

    [SerializeField]
    private GameObject canvas; // Unit UIにユニットを表示
    private Transform canvas_obj;

    private Vector3 target; // マウス追従用
    private bool existing = false; // 追従・強調表示のチェック
    Vector3 mouse; // マウスの位置取得

    private void Start()
    {
        canvas_obj = canvas.GetComponent<Transform>(); // 子に登録していく
        for(int i = 0;i < units.Length; i++)
        {
            unitUISet = Instantiate(unitUI, canvas_obj);
            unitUISet.GetComponent<UnitUI>().InputData(i, this.gameObject); 
        }
    }

    private void Update()
    {
        if (existing)
        {
            mouse = Input.mousePosition;
            mouse.z = 10;
            target = Camera.main.ScreenToWorldPoint(mouse);
            transform.position = target;
        }
    }

    public void EscapePush() // escキーを押したときの処理
    {
        if (existing)
        {
            Destroy(obj);
            Destroy(OnMouseUnit);
            existing = false;
        }
    }

    public void UI_Clicked(int i, Vector3 position)
    {
        // 強調表示の処理
        if (existing)
        {
            Destroy(obj);
        }
        obj = Instantiate(redsquare, position, Quaternion.identity, this.transform);

        // マウスに追従させる処理
        OnMouseUnit.GetComponent<SpriteRenderer>().sprite = units[i].GetComponent<SpriteRenderer>().sprite;
        OnMouseUnit.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 128);

        mouse = Input.mousePosition;
        mouse.z = 10;
        target = Camera.main.ScreenToWorldPoint(mouse);
        transform.position = target;

        Instantiate(OnMouseUnit, target, Quaternion.identity, this.transform);
        existing = true;
    }
}
