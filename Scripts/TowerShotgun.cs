using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShotgun : Tower
{
    public float sphereRadius;
    public Transform spherePosition;
    public int projectileCount;

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
                Vector3 spread = spherePosition.position - attackPoint.position + Random.insideUnitSphere * sphereRadius;
                currentProjectile.GetComponent<Rigidbody>().AddForce(spread * shootForce, ForceMode.VelocityChange);
            }
        }
        TakeDamage(selfDamage);
    }
}
