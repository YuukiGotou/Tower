using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ButtonUI : MonoBehaviour
{
    [SerializeField]
    private GameObject gamemanager;
    private GameManager gamestart;
    private RectTransform rect;

    private void Start()
    {
        gamestart = gamemanager.GetComponent<GameManager>();
        rect = GetComponent<RectTransform>();
    }
    public void Onclick()
    {
        rect.localPosition += new Vector3(0, -150, 0);
        gamestart.GameStart();
    }

    public void ReturnUI()
    {
        rect.localPosition += new Vector3(0, 150, 0);
    }
}
