using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private int sceneNumber;


    private void Start()
    {
        if (sceneNumber == 0) ClearChecker.playing[0] = true;
        if (!ClearChecker.playing[sceneNumber])
        {
            gameObject.GetComponent<Image>().color -= new Color(0, 0, 0, 0.9f);
        }
        else
        {
            gameObject.GetComponent<Image>().color += new Color(0, 0, 0, 1.0f);
        }
    }
    public void OnClick()
    {
        if (ClearChecker.playing[sceneNumber])
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
