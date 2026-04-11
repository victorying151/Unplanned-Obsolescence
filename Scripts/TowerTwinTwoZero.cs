using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTwinTwoZero : Tower
{
    public Transform attackPoint2;
    public Transform attackPoint3;
    public Transform attackPoint4;
    public Transform attackPoint5;
    public Transform attackPoint6;

    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile;
        Vector3 direction = (currentEnemy.transform.position - transform.position).normalized;
        currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        currentProjectile = Instantiate(projectile, attackPoint2.position, Quaternion.identity);
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        currentProjectile = Instantiate(projectile, attackPoint3.position, Quaternion.identity);
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        currentProjectile = Instantiate(projectile, attackPoint4.position, Quaternion.identity);
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        currentProjectile = Instantiate(projectile, attackPoint5.position, Quaternion.identity);
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        currentProjectile = Instantiate(projectile, attackPoint6.position, Quaternion.identity);
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        TakeDamage(selfDamage);
    }
}
