using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMortarZeroTwo : Tower
{
    public Transform directionToAttack;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public GameObject sideProjectile;

    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile;
        float distance = (currentEnemy.transform.position - transform.position).magnitude;
        Vector3 direction = (directionToAttack.position - transform.position).normalized;
        float angle = Mathf.Atan(directionToAttack.position.y);
        shootForce = Mathf.Sqrt(distance * 9.8f / Mathf.Sin(angle * 2));
        GameObject mainProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        mainProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        currentProjectile = Instantiate(sideProjectile, attackPoint2.position, Quaternion.identity);
        direction = (attackPoint2.position - transform.position).normalized;
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        currentProjectile.GetComponent<HomingOntoObject>().target = mainProjectile;
        currentProjectile = Instantiate(sideProjectile, attackPoint3.position, Quaternion.identity);
        direction = (attackPoint3.position - transform.position).normalized;
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        currentProjectile.GetComponent<HomingOntoObject>().target = mainProjectile;

        TakeDamage(selfDamage);
    }
}
