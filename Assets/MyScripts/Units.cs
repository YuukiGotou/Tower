using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Units : Character
{
    [SerializeField]
    private GameObject map;

    protected float size; // �L�����̍U���͈� �C�ӂŐݒ�
    protected int cost; // �L�����̌ٗp�� �C�ӂŐݒ�
    protected override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("RedSquare").SetActive(false);
            this.transform.Find("RedSquare").gameObject.SetActive(true);
            this.transform.Find("Chip").gameObject.SetActive(true);
        }

        if (Input.GetKeyDown("escape"))
        {
            this.transform.Find("RedSquare").gameObject.SetActive(false);
            this.transform.Find("Chip").gameObject.SetActive(false);
        }
    }
}
