using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] PrefabObject; // �G�̃v���n�u�I�u�W�F�N�g���i�[

    [SerializeField]
    private GameObject SpawnPoint; // �G�̃X�|�[���n�_

    [SerializeField]
    private GameObject gamemanager; // GameManager�N���X �I�u�W�F�N�g�̎擾
    private GameManager checker; // GameManager�N���X Checker�֐��̎擾

    [SerializeField]
    private GameObject StartUI;
    private ButtonUI starter;

    private int WaveEnemies; // wave���̓G����
    private int RestEnemies; // �ҋ@���E�}�b�v��ɂ���G�̎c��
    private GameObject SpawnEnemy; // �G�̎��
    private int SpawnTime; // �G�̕����X�s�[�h
    private int time;

    private void Start()
    {
        checker = gamemanager.GetComponent<GameManager>();
        starter = StartUI.GetComponent<ButtonUI>();
    }
    public void waveSet(int WaveEnemies, int SpawnTime, int spawnenemy)
    {
        this.WaveEnemies = WaveEnemies;
        RestEnemies = WaveEnemies;
        this.SpawnTime = SpawnTime;
        this.SpawnEnemy = PrefabObject[spawnenemy];
        time = SpawnTime - 10;
    }
    
    private void FixedUpdate()
    {
        if (!checker.TimeChecker())
        {
            if (WaveEnemies != 0)
            {
                time++;
                if (time == SpawnTime)
                {
                    time = 0;
                    Instantiate(SpawnEnemy, SpawnPoint.transform.position, Quaternion.identity);
                    WaveEnemies--;
                }
            }
        }
    }

    public void DisappearEnemy()
    {
        RestEnemies--;
        if(RestEnemies == 0)
        {
            starter.ReturnUI();
            checker.ClearChecker();
        }
    }
}