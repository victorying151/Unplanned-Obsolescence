using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShotgunOneZero : Tower
{
    public float sphereRadius;
    public Transform spherePosition;
    public int projectileCount;
    public Transform attackPoint2;
    public Transform spherePosition2;
    public Transform attackPoint3;
    public Transform spherePosition3;

    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile;
        Vector3 spread;
        for (int i = 0; i < projectileCount; i++)
        {
            currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
            spread = spherePosition.position - attackPoint.position + Random.insideUnitSphere * sphereRadius;
            currentProjectile.GetComponent<Rigidbody>().AddForce(spread * shootForce, ForceMode.VelocityChange);

            currentProjectile = Instantiate(projectile, attackPoint2.position, Quaternion.identity);
            spread = spherePosition2.position - attackPoint2.position + Random.insideUnitSphere * sphereRadius;
            currentProjectile.GetComponent<Rigidbody>().AddForce(spread * shootForce, ForceMode.VelocityChange);

            currentProjectile = Instantiate(projectile, attackPoint3.position, Quaternion.identity);
            spread = spherePosition3.position - attackPoint3.position + Random.insideUnitSphere * sphereRadius;
            currentProjectile.GetComponent<Rigidbody>().AddForce(spread * shootForce, ForceMode.VelocityChange);
        }
        TakeDamage(selfDamage);
    }
}
