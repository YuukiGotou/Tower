using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterMover
{
    [SerializeField]
    private int EnemyHP; // 体力 任意で設定
    [SerializeField]
    private int EnemyMoney; // 落とすお金 任意で設定

    private EnemyManager em_method;
    private LayerMask map_collision;

    public void StartUP(Vector2 direction, GameManager gm_method, EnemyManager em_method, LayerMask map_collider)
    {
        start = transform.position;
        this.direction = direction;
        target = start + direction;

        this.em_method = em_method;
        this.gm_method = gm_method;
        this.map_collision = map_collider;
    }

    protected override void Update()
    {
        base.Update();
        transform.position = Vector2.Lerp(start, target, timer / speed);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void LoopAction()
    {
        start = transform.position;
        if (Physics2D.OverlapPoint(start + direction, map_collision))
        {
            if(!SetDirection(direction.y, direction.x))
            {
                direction = new Vector2(direction.y, direction.x);
            }else if(!SetDirection(direction.y * -1.0f,direction.x * -1.0f))
            {
                direction = new Vector2(direction.y * -1.0f, direction.x * -1.0f);
            }
        }
        target = start + direction;
    }

    private bool SetDirection(float x, float y)
    {
        Vector2 vec = new Vector2(x, y);
        return Physics2D.OverlapPoint(start + vec, map_collision);
    }

    public void Intrusion()
    {
        EnemyMoney = 0;
        SelectSound("Intrusion");
    }

    public bool EnemyHPCheck(int atk)
    {
        return EnemyHP <= atk;
    }

    public void EnemyDamage(int atk)
    {
        EnemyHP -= atk;
        if(EnemyHP <= 0)
        {
            SelectSound("Death");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        em_method.DestroyEnemy();
        moneyModification(EnemyMoney);
    }

    /// <summary>
    /// 移動開始地点(Lerpで移動)
    /// </summary>
    private Vector2 start;

    /// <summary>
    /// 到達地点(Lerpの終着点)
    /// </summary>
    private Vector2 target;

    /// <summary>
    /// 移動方向
    /// </summary>
    private Vector2 direction;
}