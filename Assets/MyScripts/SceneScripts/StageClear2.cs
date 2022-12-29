using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StageClear2 : MonoBehaviour
{
    int time = 0;
    bool check = true;

    void Update()
    {
        time++;
        if(time > 120)
        {
            check = !check;
            gameObject.GetComponent<TextMeshProUGUI>().enabled = check;
            time = 0;
        }
        if (Input.GetKeyDown("space"))
        {
            if (ClearChecker.playing[5])
            {
                SceneManager.LoadScene("AllClear");
            }
            else
            {
                SceneManager.LoadScene("StageSelect");
            }
        }
    }
}
