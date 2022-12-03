using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int PlayerMoney = 10;
    public int PlayerHP = 3;

    private void Start()
    {
        SetStartButtonUI();
        sounds = mainCamera.GetComponent<Sounds>();
    }

    private void Update()
    {
        if(wave != -1)
        {
            if (!ProceedCheck())
            {
                interval++;
                if(interval == 1800)
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
        rect.localPosition = new Vector3(-295, -150, 0);
        startbutton.GetComponent<UI_StartButton>().SetManager(gameObject);
    }

    public void SelectSound(string sound_name)
    {
        sounds.SoundPlay(sound_name);
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
    }

    public void Damaged()
    {
        PlayerHP--;
        if (PlayerHP == 0)
        {
            SceneChange_GameOver();
        }
    }

    public void SceneChange_GameClear()
    {
        // �N���A��ʂɑJ��
    }

    public void SceneChange_GameOver()
    {
        // �Q�[���I�[�o�[��ʂɑJ��
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