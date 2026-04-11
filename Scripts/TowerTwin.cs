using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTwin : Tower
{
    public bool twin;
    public Transform attackPoint2;

    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile;
        if (twin)
        {
            currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        }
        else
        {
            currentProjectile = Instantiate(projectile, attackPoint2.position, Quaternion.identity);
        }
        twin = !twin;
        Vector3 direction = (currentEnemy.transform.position - transform.position).normalized;
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        TakeDamage(selfDamage);
    }
}
