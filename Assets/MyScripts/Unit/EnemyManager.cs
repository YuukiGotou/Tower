using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] PrefabObject; // 敵のプレハブオブジェクトを格納

    [SerializeField]
    private GameObject SpawnPoint; // 敵のスポーン地点

    [SerializeField]
    private GameObject gamemanager; // GameManagerクラス オブジェクトの取得
    private GameManager checker; // GameManagerクラス Checker関数の取得

    [SerializeField]
    private GameObject StartUI;
    private ButtonUI starter;

    private int WaveEnemies; // wave毎の敵総数
    private int RestEnemies; // 待機中・マップ上にいる敵の残数
    private GameObject SpawnEnemy; // 敵の種類
    private int SpawnTime; // 敵の沸きスピード
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