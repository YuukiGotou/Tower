using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapColor : MonoBehaviour
{
    [SerializeField]
    private GameObject unitmanager;
    private UnitManager um_method;

    private Tilemap tilemap;
    [SerializeField]
    private GameObject square; // マップタイルの強調表示
    GameObject obj;
    private bool existing = false;

    private void Start()
    {
        um_method = unitmanager.GetComponent<UnitManager>();
        tilemap = GetComponent<Tilemap>();
    }
    private void OnMouseEnter()
    {
        if (um_method.ExistingCheck())
        {
            obj = Instantiate(square);
            existing = true;
        }
    }

    private void OnMouseOver()
    {
        if (existing)
        {
            Vector3 target = um_method.GetPosition();
            Vector3Int tileposition = new Vector3Int((int)Mathf.Floor(target.x), (int)Mathf.Floor(target.y), 0);
            Vector3 center = new Vector3((float)tileposition.x + 0.5f, (float)tileposition.y + 0.5f, 0);
            if (um_method.CostCheck())
            {
                if (Input.GetMouseButton(0))
                {
                    um_method.SetUnit(center); // ユニットを置く
                    tilemap.SetTile(tileposition, null);
                }
                else
                {
                    obj.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0.5f); // 緑色
                    obj.transform.position = center;
                }
            }
            else
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.5f); // 緑色
                obj.transform.position = center;
            }
        }
    }

    private void OnMouseExit()
    {
        if (existing)
        {
            Destroy(obj);
            existing = false;
        }
    }

    public void ChangeColor(bool existing)
    {
        GetComponent<Renderer>().enabled = existing;
    }
}