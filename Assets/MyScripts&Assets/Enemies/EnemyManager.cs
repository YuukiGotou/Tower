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
    private LayerMask map_collision;

    private void Start()
    {
        spawnplace = spawnPlace.transform.position;
        gm_method = gameManager.GetComponent<GameManager>();
        startdirection = spawnPlace.GetComponent<StartDirection>().GetStartDirection();
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
        obj.GetComponent<Enemy>().StartUP(startdirection, gm_method, gameObject.GetComponent<EnemyManager>(), map_collision);
        stand_by_enemy--;
        timer = 0;
    }

    public void DestroyEnemy()
    {
        rest_enemy--;
        if (rest_enemy == 0)
        {
            gm_method.ProceedChange();
            gm_method.SetStartButtonUI();
            proceed = false;
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
}

[System.Serializable]
public class WaveData
{
    [SerializeField]
    public int TotalEnemies;
    public int SpawnInterval;
    public int EnemyType;
}