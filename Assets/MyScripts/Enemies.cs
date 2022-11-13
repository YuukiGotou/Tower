using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Enemies : Character
{
    protected int HP; // �̗� �C�ӂŐݒ�
    protected int Money; // ���Ƃ����z �C�ӂŐݒ�
    private Vector2 start; // �ړ��J�n�n�_
    private Vector2 end; // ���B�_(start ���� end �܂ł�"Lerp"�ňړ�)
    private Vector2 move; // time - speed�Ԃ̈ړ�����
    public LayerMask map; // mapcollision

    protected override void Start()
    {
        base.Start();
        start = transform.position;
        move = new Vector2(-1.0f, 0); // �������� = ��
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
        base.FixedUpdate(); // timer = speed�̏ꍇ"LoopAction"�̎��s��timer�̃��Z�b�g
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