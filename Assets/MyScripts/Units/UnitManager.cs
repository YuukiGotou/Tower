using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    [SerializeField]
    private GameObjectData[] Units; // ユニットの登録

    [SerializeField]
    private GameObject canvas;
    private Transform canvas_transform; // 親クラス登録
    [SerializeField]
    private GameObject gamemanager;
    private GameManager gm_method; // コスト, 進行度の参照 
    [SerializeField]
    private GameObject mapcolor;
    private MapColor mc_method;

    [SerializeField]
    private GameObject unitUI_prefab; // UnitUIの生成用オブジェクト
    [SerializeField]
    private GameObject sliderUI; // ゲージ表示用オブジェクト
    [SerializeField]
    private GameObject WindowUI; // ゲージ表示用オブジェクト

    [SerializeField]
    private GameObject Redsquare_prefab; // 強調表示用
    [SerializeField]
    private GameObject Areaimage_prefab; // 攻撃範囲表示用

    private void Start()
    {
        // 画面にユニットのUIを登録する
        gm_method = gamemanager.GetComponent<GameManager>();
        mc_method = mapcolor.GetComponent<MapColor>();
        canvas_transform = canvas.GetComponent<Transform>();
        for (int i = 0; i < Units.Length; i++)
        {
            Sprite sprite = Units[i].unit.GetComponent<SpriteRenderer>().sprite;
            GameObject unitUISet = Instantiate(unitUI_prefab, canvas_transform);
            RectTransform rect = unitUISet.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(-190 + (85 * i), -150, 0);
            unitUISet.GetComponent<Image>().sprite = sprite;
            unitUISet.GetComponent<UnitUI>().InputData(gameObject, WindowUI, i, canvas_transform);
        }
    }

    private void Update()
    {
        if (existing)
        {
            if (Input.GetKeyDown("escape"))
            {
                DestroyUI();
                existing = false;
                mc_method.ChangeColor(existing);
            }
            else
            {
                target = GetPosition();
                unitimage.transform.position = target;
                areaimage.transform.position = target;
            }
        }
    }
    public void UI_Clicked(Sprite sprite, Vector3 position, int unitnumber)
    {
        if (existing)
        {
            DestroyUI();
        }
        selection_number = unitnumber;
        redsquare = Instantiate(Redsquare_prefab, position, Quaternion.identity, this.transform);

        target = GetPosition();
        unitimage = new GameObject("UnitImage");
        unitimage.AddComponent<SpriteRenderer>();
        unitimage.GetComponent<SpriteRenderer>().sprite = sprite;
        unitimage.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        unitimage.transform.position = target;

        areaimage = Instantiate(Areaimage_prefab);
        areaimage.transform.position = target;
        float size = (float)Units[selection_number].unit.GetComponent<Unit>().GetAttackArea();
        areaimage.transform.localScale = new Vector3(size * 2, size * 2, 1);
        this.selection_cost = Units[unitnumber].unit.GetComponent<Unit>().GetCost();

        existing = true;
        mc_method.ChangeColor(existing);
    }

    public Vector3 GetPosition()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 10;
        return Camera.main.ScreenToWorldPoint(mouse);
    }

    public bool CostCheck()
    {
        return gm_method.MoneyCheck(selection_cost);
    }

    public void SetUnit(Vector3 position)
    {
        gm_method.MoneyModification(-selection_cost);
        GameObject obj = Instantiate(Units[selection_number].unit, position, Quaternion.identity);

        Vector3 slider_vec = position + new Vector3(0, -0.45f, 0);
        GameObject obj2 = Instantiate(sliderUI, canvas_transform);
        obj2.transform.position = slider_vec;
        obj.GetComponent<Unit>().StartUP(gm_method, obj2, Areaimage_prefab,Units[selection_number].effect);
    }

    private void DestroyUI()
    {
        Destroy(redsquare);
        Destroy(unitimage);
        Destroy(areaimage);
    }

    public bool ExistingCheck()
    {
        return existing;
    }

    public int GetAtk(int num)
    {
        return Units[num].unit.GetComponent<Unit>().GetAtk();
    }
    public int GetCost(int num)
    {
        return Units[num].unit.GetComponent<Unit>().GetCost();
    }
    public int GetSpeed(int num)
    {
        return Units[num].unit.GetComponent<Unit>().GetSpeed();
    }

    /// <summary>
    /// 現在選択しているユニットの番号を保有
    /// </summary>
    private int selection_number;

    /// <summary>
    /// 現在選択しているユニットのコストを保有
    /// </summary>
    private int selection_cost;

    /// <summary>
    /// UIがクリックされているかどうかを判定
    /// </summary>
    private bool existing = false;

    /// <summary>
    /// 赤枠オブジェクト
    /// </summary>
    private GameObject redsquare;

    /// <summary>
    /// ユニット画像
    /// </summary>
    private GameObject unitimage;

    /// <summary>
    /// 攻撃範囲
    /// </summary>
    private GameObject areaimage;

    /// <summary>
    /// マウス座標
    /// </summary>
    private Vector3 target;
}

[System.Serializable]
public class GameObjectData
{
    public GameObject unit;
    public GameObject effect;
}