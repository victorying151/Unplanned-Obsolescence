using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOcto : Tower
{
    public List<Transform> points;
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
        GameObject currentProjectile;
        Vector3 direction;
        for (int i = points.Count-1; i >= 0; i--)
        {
            currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
            direction = (points[i].position - attackPoint.position).normalized;
            currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        }
        TakeDamage(selfDamage);
    }
}
