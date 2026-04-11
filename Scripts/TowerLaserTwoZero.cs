using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLaserTwoZero : Tower
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
        if (currentEnemy != null)
        {
            transform.LookAt(new Vector3(currentEnemy.transform.position.x, transform.position.y, currentEnemy.transform.position.z), Vector3.up);
            projectile.SetActive(true);
            TakeDamage(selfDamage * Time.deltaTime);
        }
        else if (currentEnemy == null)
        {
            projectile.SetActive(false);
        }
    }
}
