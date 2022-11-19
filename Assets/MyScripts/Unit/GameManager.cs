using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private WaveData[] wavedata; // wave���̓G�̐�, ��������, �G�̎��(�蓮�œ���)

    [SerializeField]
    private GameObject enemymanager; // EnemyManager�N���X �I�u�W�F�N�g�̎擾("StartArea")
    private EnemyManager waveSet; // EnemyManager�N���X waveSet�֐��̌Ăяo���p

    [SerializeField]
    private GameObject StartUI;
    private ButtonUI starter;

    private bool breaktime = true; // wave�Ԃ̋x�~�p�t���O
    private int wave = 0; // ���݂�wave
    private int start = 0; // wave�Ԃ̋x�~���� ( 0 - 1800 )
    private int PlayerHP = 3;

    private void Start()
    {
        waveSet = enemymanager.GetComponent<EnemyManager>();
        starter = StartUI.GetComponent<ButtonUI>();
    }

    private void Update()
    {
        if (breaktime)
        {
            if(wave != 0)
            {
                start++;
                if(start == 120)
                {
                    start = 0;
                    waveSet.waveSet(wavedata[wave].TotalEnemies, wavedata[wave].SpawnInterval, wavedata[wave].EnemyType);
                    starter.Onclick();
                    breaktime = false;
                }
            }
        }
    }

    public bool TimeChecker()
    {
        return breaktime;
    }

    public void ClearChecker()
    {
        wave++;
        if (wave == wavedata.Length)
        {
            // �Q�[���N���A�V�[���Ƀ`�F���W
        }
        breaktime = true;
    }

    public void DeathChecker()
    {
        if(PlayerHP == 0)
        {
            // �Q�[���I�[�o�[�V�[���Ƀ`�F���W
        }
    }

    public void GameStart()
    {
        start = 0;
        waveSet.waveSet(wavedata[wave].TotalEnemies, wavedata[wave].SpawnInterval, wavedata[wave].EnemyType);
        breaktime = false;
    }
}

[System.Serializable]
public class WaveData
{
    [SerializeField]
    public int TotalEnemies;
    public int SpawnInterval;
    public int EnemyType;
}