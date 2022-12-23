using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;
    private GameObject startbutton; // �X�^�[�g�{�^���̕ێ��p

    [SerializeField]
    private GameObject mainCamera;
    private Sounds sounds; // �����ݒ�

    [SerializeField]
    private GameObject canvas; // �X�^�[�g�{�^����UI�o�^�p

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
    /// false = ��i�s, true = �i�s��
    /// </summary>
    private bool proceed = false;

    /// <summary>
    /// ���݂�wave�� (0����J�E���g)
    /// </summary>
    private int wave = -1;

    /// <summary>
    /// �v���C���[�����j�b�g��ݒu����p�̎���(30�b)
    /// </summary>
    private int interval = 0;
}