using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Units; // ���j�b�g�̓o�^

    [SerializeField]
    private GameObject canvas;
    private Transform canvas_transform; // �e�N���X�o�^
    [SerializeField]
    private GameObject gamemanager;
    private GameManager gm_method; // �R�X�g, �i�s�x�̎Q�� 
    [SerializeField]
    private GameObject mapcolor;
    private MapColor mc_method;

    [SerializeField]
    private GameObject unitUI_prefab; // UnitUI�̐����p�I�u�W�F�N�g
    [SerializeField]
    private GameObject sliderUI; // �Q�[�W�\���p�I�u�W�F�N�g

    [SerializeField]
    private GameObject Redsquare_prefab; // �����\���p
    [SerializeField]
    private GameObject Areaimage_prefab; // �U���͈͕\���p

    private void Start()
    {
        // ��ʂɃ��j�b�g��UI��o�^����
        gm_method = gamemanager.GetComponent<GameManager>();
        mc_method = mapcolor.GetComponent<MapColor>();
        canvas_transform = canvas.GetComponent<Transform>();
        for (int i = 0; i < Units.Length; i++)
        {
            Sprite sprite = Units[i].GetComponent<SpriteRenderer>().sprite;
            GameObject unitUISet = Instantiate(unitUI_prefab, canvas_transform);
            RectTransform rect = unitUISet.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(-210 + (80 * i), -150, 0);
            unitUISet.GetComponent<Image>().sprite = sprite;
            unitUISet.GetComponent<UnitUI>().InputData(gameObject, i);
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

        redsquare = Instantiate(Redsquare_prefab, position, Quaternion.identity, this.transform);

        target = GetPosition();
        unitimage = new GameObject("UnitImage");
        unitimage.AddComponent<SpriteRenderer>();
        unitimage.GetComponent<SpriteRenderer>().sprite = sprite;
        unitimage.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        unitimage.transform.position = target;

        areaimage = Instantiate(Areaimage_prefab);
        areaimage.transform.position = target;
        float size = (float)Units[selection_number].GetComponent<Unit>().GetAttackArea();
        areaimage.transform.localScale = new Vector3(size * 2, size * 2, 1);
        this.selection_cost = Units[unitnumber].GetComponent<Unit>().GetCost();

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
        GameObject obj = Instantiate(Units[selection_number], position, Quaternion.identity);

        Vector3 slider_vec = position + new Vector3(0, -0.45f, 0);
        GameObject obj2 = Instantiate(sliderUI, canvas_transform);
        obj2.transform.position = slider_vec;
        obj.GetComponent<Unit>().StartUP(gm_method, obj2, Areaimage_prefab);
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

    /// <summary>
    /// ���ݑI�����Ă��郆�j�b�g�̔ԍ���ۗL
    /// </summary>
    private int selection_number;

    /// <summary>
    /// ���ݑI�����Ă��郆�j�b�g�̃R�X�g��ۗL
    /// </summary>
    private int selection_cost;

    /// <summary>
    /// UI���N���b�N����Ă��邩�ǂ����𔻒�
    /// </summary>
    private bool existing = false;

    /// <summary>
    /// �Ԙg�I�u�W�F�N�g
    /// </summary>
    private GameObject redsquare;

    /// <summary>
    /// ���j�b�g�摜
    /// </summary>
    private GameObject unitimage;

    /// <summary>
    /// �U���͈�
    /// </summary>
    private GameObject areaimage;

    /// <summary>
    /// �}�E�X���W
    /// </summary>
    private Vector3 target;
}