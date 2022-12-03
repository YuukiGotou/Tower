using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    private GameObject unitmanager;
    private int unitnumber; // "UnitManager"����I�u�W�F�N�g���Q��

    public void InputData(GameObject unitmanager, int unitnumber) // �I�u�W�F�N�g�̓o�^
    {
        this.unitmanager = unitmanager;
        this.unitnumber = unitnumber;
    }

    private void OnMouseOver()
    {
        // �f�[�^�E�B���h�E�̕\��
        UnitManager showwindow = unitmanager.GetComponent<UnitManager>();
    }

    public void OnClick() // �N���b�N���̏���
    {
        Sprite sprite = GetComponent<Image>().sprite;
        unitmanager.GetComponent<UnitManager>().UI_Clicked(sprite, transform.position, unitnumber);
    }
}