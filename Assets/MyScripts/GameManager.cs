using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;
    private GameObject startbutton; // スタートボタンの保持用

    [SerializeField]
    private GameObject mainCamera;
    private Sounds sounds; // 音響設定

    [SerializeField]
    private GameObject canvas; // スタートボタンのUI登録用

    [SerializeField]
    private GameObject HPText;
    [SerializeField]
    private GameObject MoneyText;

    public int PlayerMoney = 10;
    public int PlayerHP = 3;

    private void Start()
    {
        SetStartButtonUI();
        sounds = mainCamera.GetComponent<Sounds>();
        HPText.GetComponent<StatusText>().SetStatus(PlayerHP);
        MoneyText.GetComponent<StatusText>().SetStatus(PlayerMoney);
    }

    private void Update()
    {
        if(wave != -1)
        {
            if (!ProceedCheck())
            {
                interval++;
                if(interval == 9000)
                {
                    WaveChange();
                }
            }
        }
    }
    public void SetStartButtonUI()
    {
        startbutton = Instantiate(startButton, canvas.transform);
        RectTransform rect = startbutton.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(-290, -150, 0);
        startbutton.GetComponent<UI_StartButton>().SetManager(gameObject);
    }

    public void PlaySound(AudioClip audio_name)
    {
        sounds.SoundPlay(audio_name);
    }

    public bool ProceedCheck()
    {
        return proceed;
    }

    public void ProceedChange()
    {
        proceed = !proceed;
    }

    public int WaveCheck()
    {
        return wave;
    }

    public void WaveChange()
    {
        wave++;
        interval = 0;
        Destroy(startbutton);
        ProceedChange();
    }
    public bool MoneyCheck(int money)
    {
        return PlayerMoney >= money;
    }

    public void MoneyModification(int money)
    {
        PlayerMoney += money;
        MoneyText.GetComponent<StatusText>().SetStatus(PlayerMoney);
    }

    public void Damaged()
    {
        PlayerHP--;
        if (PlayerHP == 0)
        {
            SceneChange_GameOver();
        }
        HPText.GetComponent<StatusText>().SetStatus(PlayerHP);
    }

    public bool HPZeroCheck()
    {
        return PlayerHP == 0;
    }

    public void SceneChange_GameClear()
    {
        SceneManager.LoadScene("StageClear");
    }

    public void SceneChange_GameOver()
    {
        SceneManager.LoadScene("GAMEOVER");
    }




    /// <summary>
    /// false = 非進行, true = 進行中
    /// </summary>
    private bool proceed = false;

    /// <summary>
    /// 現在のwave数 (0からカウント)
    /// </summary>
    private int wave = -1;

    /// <summary>
    /// プレイヤーがユニットを設置する用の時間(30秒)
    /// </summary>
    private int interval = 0;
}