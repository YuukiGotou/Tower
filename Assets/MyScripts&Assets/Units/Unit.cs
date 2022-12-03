using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    single,
    area
}

public class Unit : CharacterMover
{
    [SerializeField]
    private int cost;
    [SerializeField]
    private int atk;
    [SerializeField]
    private float atkarea;
    [SerializeField]
    private AttackType attackType;

    private List<GameObject> targetEnemy;

    public void StartUP(GameManager gm_method)
    {
        this.gm_method = gm_method;
        targetEnemy = new List<GameObject>();
        targetEnemy.Add(gameObject);
        GetComponent<CircleCollider2D>().radius = atkarea;
    }

    protected override void Update()
    {
        if (gm_method.ProceedCheck())
        {
            if (timer < speed)
            {
                base.Update();
            }
        }
        else
        {
            timer = speed;
        }
    }

    protected override void FixedUpdate()
    {
        if (targetEnemy.Count != 1)
        {
            base.FixedUpdate();
        }
    }

    protected override void LoopAction()
    {
        switch (attackType)
        {
            case AttackType.single:
                EnemyListCheck(1);
                break;
            case AttackType.area:
                for (int i = targetEnemy.Count - 1; i != 0; i--)
                {
                    EnemyListCheck(i);
                }
                break;
        }
    }

    public int GetCost()
    {
        return cost;
    }

    public float GetAttackArea()
    {
        return atkarea;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            targetEnemy.Add(collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        targetEnemy.Remove(collider.gameObject);
    }

    private void EnemyListCheck(int n)
    {
        Enemy t_method = targetEnemy[n].GetComponent<Enemy>();
        if (t_method.EnemyHPCheck(atk))
        {
            targetEnemy.Remove(targetEnemy[n]);
        }
        t_method.EnemyDamage(atk);
    }
}