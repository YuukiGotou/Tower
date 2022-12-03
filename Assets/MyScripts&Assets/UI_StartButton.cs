using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class UI_StartButton : MonoBehaviour
{
    private GameObject gameManager;

    public void SetManager(GameObject gameManager)
    {
        this.gameManager = gameManager;
    }
    public void Onclick()
    {
        gameManager.GetComponent<GameManager>().WaveChange();
    }
}
