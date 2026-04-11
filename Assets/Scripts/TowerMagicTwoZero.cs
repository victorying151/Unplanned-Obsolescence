using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMagicTwoZero : Tower
{
    public int magicLeft;
    public int maxMagic;
    public List<Transform> points;
    public GameObject smallProjectile;
    public float timeBetweenCharge;
    protected override void Start()
    {
        currentThreshold = thresholds[0];
        thresholds.Remove(currentThreshold);
        currentAppearance = appearances[0];
        appearances.Remove(currentAppearance);
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
        InvokeRepeating("Recharge", 0f, timeBetweenCharge);
    }

    protected override void Update()
    {
        if (currentEnemy != null)
        {
            float distance = (currentEnemy.transform.position - transform.position).magnitude;
            if (distance > range)
            {
                currentEnemy = null;
            }
        }
        if (currentEnemy == null)
        {
            FindEnemy();
        }
        if (currentEnemy != null && !alreadyAttacked)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        if (magicLeft != 0)
        {
            if(magicLeft == maxMagic)
            {
                Instantiate(projectile, attackPoint.position, Quaternion.identity);
            }
            else
            {
                if(magicLeft < points.Count)
                {
                    Instantiate(smallProjectile, points[magicLeft].position, Quaternion.identity);
                }
            }
            TakeDamage(selfDamage);
            magicLeft -= 1;
        }
    }

    public void Recharge()
    {
        if(magicLeft < maxMagic)
        {
            magicLeft += 1;
        }
    }
}
