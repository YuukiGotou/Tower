using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver2 : MonoBehaviour
{
    int time = 0;
    bool check = true;

    void Update()
    {
        time++;
        if(time > 240)
        {
            check = !check;
            gameObject.GetComponent<TextMeshProUGUI>().enabled = check;
            time = 0;
        }
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("StageSelect");
        }
    }
}
