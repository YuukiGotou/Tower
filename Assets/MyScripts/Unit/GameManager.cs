using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private WaveData[] wavedata; // wave毎の敵の数, 沸き時間, 敵の種類(手動で入力)

    [SerializeField]
    private GameObject enemymanager; // EnemyManagerクラス オブジェクトの取得("StartArea")
    private EnemyManager waveSet; // EnemyManagerクラス waveSet関数の呼び出し用

    [SerializeField]
    private GameObject StartUI;
    private ButtonUI starter;

    private bool breaktime = true; // wave間の休止用フラグ
    private int wave = 0; // 現在のwave
    private int start = 0; // wave間の休止時間 ( 0 - 1800 )
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
            // ゲームクリアシーンにチェンジ
        }
        breaktime = true;
    }

    public void DeathChecker()
    {
        if(PlayerHP == 0)
        {
            // ゲームオーバーシーンにチェンジ
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