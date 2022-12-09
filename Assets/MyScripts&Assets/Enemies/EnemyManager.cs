using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyData; // 敵の種類の格納

    [SerializeField]
    private WaveData[] waveData; // wave毎の敵の種類, 敵の数, 沸き時間(手動で入力)
    private GameObject spawnEnemy; // 指定のwaveにスポーンする敵

    [SerializeField]
    private GameObject spawnPlace;
    private Vector3 spawnplace; // 敵のスポーン地点

    [SerializeField]
    private GameObject gameManager;
    private GameManager gm_method; // ゲームの進行状況の管理

    [SerializeField]
    private GameObject canvas;
    private Transform canvas_transform;
    [SerializeField]
    private GameObject sliderUI; // ゲージ表示用オブジェクト

    [SerializeField]
    private GameObject waveText; // テキスト表示用
    private StatusText2 wt_method;

    [SerializeField]
    private LayerMask map_collision;

    private void Start()
    {
        spawnplace = spawnPlace.transform.position;
        gm_method = gameManager.GetComponent<GameManager>();
        startdirection = spawnPlace.GetComponent<StartDirection>().GetStartDirection();
        canvas_transform = canvas.GetComponent<Transform>();
        MaxWave = waveData.Length;
        wt_method = waveText.GetComponent<StatusText2>();
        wt_method.SetWave(MaxWave, 1);
    }

    private void FixedUpdate()
    {
        if (proceed) // ゲーム進行中の処理
        {
            timer++;
            if(timer == spawn_time)
            {
                if(stand_by_enemy > 0)
                {
                    Spawn();
                }
            }
        }
        else
        {
            if (gm_method.ProceedCheck()) // 切り替わった瞬間の処理
            {
                WaveSet();
            }
        }
    }

    private void WaveSet()
    {
        int wave = gm_method.WaveCheck();
        spawnEnemy = enemyData[wave];
        stand_by_enemy = waveData[wave].TotalEnemies;
        rest_enemy = waveData[wave].TotalEnemies;
        spawn_time = waveData[wave].SpawnInterval;
        timer = -60;
        proceed = true;
    }

    private void Spawn()
    {
        GameObject obj = Instantiate(spawnEnemy, spawnplace, Quaternion.identity, gameObject.transform);
        Vector3 vec = spawnplace + new Vector3(0, 0.4f, 0);
        GameObject obj2 = Instantiate(sliderUI, vec, Quaternion.identity, canvas_transform);
        obj.GetComponent<Enemy>().StartUP(startdirection, gm_method, gameObject.GetComponent<EnemyManager>(), map_collision, obj2);
        stand_by_enemy--;
        timer = 0;
    }

    public void DestroyEnemy()
    {
        rest_enemy--;
        if (rest_enemy == 0)
        {
            gm_method.ProceedChange();
            int wave = gm_method.WaveCheck() + 1;
            if(wave == MaxWave && !gm_method.HPZeroCheck())
            {
                gm_method.SceneChange_GameClear();
            }
            else
            {
                gm_method.SetStartButtonUI();
                wt_method.SetNowWave(wave + 2);
                proceed = false;
            }
        }
    }

    /// <summary>
    /// waveでまだ出現していないEnemyの数
    /// </summary>
    private int stand_by_enemy = 0;

    /// <summary>
    /// waveで出現しているものを含めて、全体で残っているEnemyの数
    /// </summary>
    private int rest_enemy = 0;

    /// <summary>
    /// waveで敵がスポーンする間隔
    /// </summary>
    private int spawn_time = 0;

    /// <summary>
    /// timer == spawn_time のときスポーン
    /// </summary>
    private int timer = 0;

    /// <summary>
    /// gameManagerの進行状況引継ぎ
    /// </summary>
    private bool proceed = false;

    /// <summary>
    /// スタート時の敵の進行方向
    /// </summary>
    private Vector2 startdirection;
    
    /// <summary>
    /// wave最大数
    /// </summary>
    private int MaxWave;
}

[System.Serializable]
public class WaveData
{
    [SerializeField]
    public int TotalEnemies;
    public int SpawnInterval;
    public int EnemyType;
}