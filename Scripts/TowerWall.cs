using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWall : Tower
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {

    }

    public void UpdateStore()
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
}
