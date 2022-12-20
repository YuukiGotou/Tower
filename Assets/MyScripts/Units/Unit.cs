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
    private GameObject effect;
    [SerializeField]
    private int cost;
    [SerializeField]
    private int atk;
    [SerializeField]
    private float atkarea;
    [SerializeField]
    private AttackType attackType;
    private GameObject attackcircle;
    private GameObject obj;

    private List<GameObject> targetEnemy;

    public void StartUP(GameManager gm_method, GameObject sliderUI, GameObject atkCircle,GameObject effect)
    {
        this.gm_method = gm_method;
        this.sliderUI = sliderUI;
        this.effect = effect;

        targetEnemy = new List<GameObject>();
        targetEnemy.Add(gameObject);
        GetComponent<CircleCollider2D>().radius = atkarea;

        sUI_method = sliderUI.GetComponent<SliderUI>();
        sUI_method.SetMaxValue(speed);
        attackcircle = atkCircle;
        attackcircle.transform.localScale = new Vector3(atkarea * 2, atkarea * 2, 1);
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
        sUI_method.ValueSet(timer);
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
                Vector3 vec = targetEnemy[1].transform.position;
                Instantiate(effect, vec, Quaternion.identity, gameObject.transform);
                EnemyListCheck(1);
                break;
            case AttackType.area:
                for (int i = targetEnemy.Count - 1; i != 0; i--)
                {
                    EnemyListCheck(i);
                }
                Instantiate(effect, transform.position, Quaternion.identity, gameObject.transform);
                break;
        }
    }

    public int GetCost()
    {
        return cost;
    }
    public int GetAtk()
    {
        return atk;
    }
    public int GetSpeed()
    {
        float n = 1 / speed * 1000;
        return (int)n;
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

    private void OnMouseEnter()
    {
        obj = Instantiate(attackcircle, transform.position, Quaternion.identity);
    }

    private void OnMouseExit()
    {
        Destroy(obj);
    }
}