using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyData; // �G�̎�ނ̊i�[

    [SerializeField]
    private WaveData[] waveData; // wave���̓G�̎��, �G�̐�, ��������(�蓮�œ���)
    private GameObject spawnEnemy; // �w���wave�ɃX�|�[������G

    [SerializeField]
    private GameObject spawnPlace;
    private Vector3 spawnplace; // �G�̃X�|�[���n�_

    [SerializeField]
    private GameObject gameManager;
    private GameManager gm_method; // �Q�[���̐i�s�󋵂̊Ǘ�

    [SerializeField]
    private GameObject canvas;
    private Transform canvas_transform;
    [SerializeField]
    private GameObject sliderUI; // �Q�[�W�\���p�I�u�W�F�N�g

    [SerializeField]
    private GameObject waveText; // �e�L�X�g�\���p
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
        if (proceed) // �Q�[���i�s���̏���
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
            if (gm_method.ProceedCheck()) // �؂�ւ�����u�Ԃ̏���
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
    /// wave�ł܂��o�����Ă��Ȃ�Enemy�̐�
    /// </summary>
    private int stand_by_enemy = 0;

    /// <summary>
    /// wave�ŏo�����Ă�����̂��܂߂āA�S�̂Ŏc���Ă���Enemy�̐�
    /// </summary>
    private int rest_enemy = 0;

    /// <summary>
    /// wave�œG���X�|�[������Ԋu
    /// </summary>
    private int spawn_time = 0;

    /// <summary>
    /// timer == spawn_time �̂Ƃ��X�|�[��
    /// </summary>
    private int timer = 0;

    /// <summary>
    /// gameManager�̐i�s�󋵈��p��
    /// </summary>
    private bool proceed = false;

    /// <summary>
    /// �X�^�[�g���̓G�̐i�s����
    /// </summary>
    private Vector2 startdirection;
    
    /// <summary>
    /// wave�ő吔
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