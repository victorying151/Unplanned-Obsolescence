using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMagic : Tower
{
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
}
