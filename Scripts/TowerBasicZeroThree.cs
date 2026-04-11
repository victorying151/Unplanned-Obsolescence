using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBasicZeroThree : Tower
{
    public bool twin;
    public Transform attackPoint2;
    public float fastSpeed;
    public GameObject currentTarget;

    public override void Attack()
    {
        alreadyAttacked = true;
        if(currentEnemy == currentTarget)
        {
            Invoke("ResetAttack", fastSpeed);
        }
        else
        {
            Invoke("ResetAttack", timeBetweenAttacks);
        }
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
        currentProjectile.transform.forward = new Vector3(transform.forward.x, 0, transform.forward.z);
        TakeDamage(selfDamage);
        currentTarget = currentEnemy;
    }
}
