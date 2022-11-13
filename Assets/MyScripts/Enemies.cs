using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Enemies : Character
{
    protected int HP; // 体力 任意で設定
    protected int Money; // 落とす金額 任意で設定
    private Vector2 start; // 移動開始地点
    private Vector2 end; // 到達点(start から end までを"Lerp"で移動)
    private Vector2 move; // time - speed間の移動方向
    public LayerMask map; // mapcollision

    protected override void Start()
    {
        base.Start();
        start = transform.position;
        move = new Vector2(-1.0f, 0); // 初期方向 = 左
        end = start + move;
    }

    protected override void FixedUpdate()
    {
        if (HP <= 0)
        {
            SelectSound("Death");
            Destroy(gameObject);
        }
        transform.position = Vector2.Lerp(start, end, TimeCount());
        base.FixedUpdate(); // timer = speedの場合"LoopAction"の実行とtimerのリセット
    }

    protected override void LoopAction()
    {
        start = transform.position;
        if (Physics2D.OverlapPoint(start + move, map))
        {
            if (!SetDirection(move.y, move.x))
            {
                move = new Vector2(move.y, move.x);
            }
            else if (!SetDirection(move.y * -1.0f, move.x * -1.0f))
            {
                move = new Vector2(move.y * -1.0f, move.x * -1.0f);
            }
        }
        end = start + move;
    }

    bool SetDirection(float x, float y)
    {
        Vector2 vec = new Vector2(x, y);
        return Physics2D.OverlapPoint(start + vec, map);
    }
}