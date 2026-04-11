using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMortar : Tower
{
    public Transform directionToAttack;

    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);

        float distance = (currentEnemy.transform.position - transform.position).magnitude;
        Vector3 direction = (directionToAttack.position - transform.position).normalized;
        float angle = Mathf.Atan(directionToAttack.position.y);
        shootForce = Mathf.Sqrt(distance * 9.8f / Mathf.Sin(angle * 2));
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);

        TakeDamage(selfDamage);
    }
}
