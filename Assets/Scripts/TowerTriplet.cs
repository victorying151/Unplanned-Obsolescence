using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTriplet : Tower
{
    public bool twin;
    public Transform attackPoint2;
    public Transform attackPoint3;

    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile;
        Vector3 direction = (currentEnemy.transform.position - transform.position).normalized;
        if (twin)
        {
            currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
            currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
            
        }
        else
        {
            currentProjectile = Instantiate(projectile, attackPoint2.position, Quaternion.identity);
            currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
            currentProjectile = Instantiate(projectile, attackPoint3.position, Quaternion.identity);
            currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        }
        twin = !twin;
        TakeDamage(selfDamage);

    }
}
