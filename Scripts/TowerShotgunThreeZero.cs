using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShotgunThreeZero : Tower
{
    public float sphereRadius;
    public Transform spherePosition;
    public int projectileCount;
    public float randomForce;

    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile;
        for(int i = 0; i<projectileCount; i++)
        {
            currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);

            if (shootForce != 0f)
            {
                Vector3 spread = (spherePosition.position - attackPoint.position + Random.insideUnitSphere * sphereRadius).normalized * Random.Range(1-randomForce, 1+randomForce);
                currentProjectile.GetComponent<Rigidbody>().AddForce(spread * shootForce, ForceMode.VelocityChange);
            }
        }
        TakeDamage(selfDamage);
    }
}
