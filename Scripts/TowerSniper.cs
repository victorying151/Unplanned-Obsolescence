using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSniper : Tower
{
    public override void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        
        if(shootForce != 0f)
        {
            float distance = (currentEnemy.transform.position - transform.position).magnitude;
            Vector3 enemyPosition = currentEnemy.transform.position + (currentEnemy.GetComponent<Rigidbody>().velocity * distance / shootForce);
            Vector3 direction = (enemyPosition - transform.position).normalized;
            currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        }
        TakeDamage(selfDamage);
    }
}
