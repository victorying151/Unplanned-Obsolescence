using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLaser : Tower
{
    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        currentProjectile.transform.forward = new Vector3(transform.forward.x, 0, transform.forward.z);
        TakeDamage(selfDamage);
    }
}
