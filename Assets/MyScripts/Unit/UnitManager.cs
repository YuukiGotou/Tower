using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] units; // ���j�b�g�̓o�^
    private GameObject OnMouseUnit; // �}�E�X�ɒǏ]���郆�j�b�g

    [SerializeField]
    private GameObject unitUI; // ���j�b�g��UI�p(���Button UI������)
    private GameObject unitUISet;

    [SerializeField]
    private GameObject redsquare; // �����\���I�u�W�F�N�g����
    private GameObject obj;

    [SerializeField]
    private GameObject canvas; // Unit UI�Ƀ��j�b�g��\��
    private Transform canvas_obj;

    private Vector3 target; // �}�E�X�Ǐ]�p
    private bool existing = false; // �Ǐ]�E�����\���̃`�F�b�N
    Vector3 mouse; // �}�E�X�̈ʒu�擾

    private void Start()
    {
        canvas_obj = canvas.GetComponent<Transform>(); // �q�ɓo�^���Ă���
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

    public void EscapePush() // esc�L�[���������Ƃ��̏���
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
        // �����\���̏���
        if (existing)
        {
            Destroy(obj);
        }
        obj = Instantiate(redsquare, position, Quaternion.identity, this.transform);

        // �}�E�X�ɒǏ]�����鏈��
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
