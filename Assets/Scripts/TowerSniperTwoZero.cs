using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSniperTwoZero : Tower
{
    public float timeSinceLastAttack;
    public GameObject chargeShot;
    public float timeToCharge;
    // Start is called before the first frame update
    // Update is called once per frame
    protected override void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        base.Update();
    }

    public override void Attack()
    {
        alreadyAttacked = true;
        
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile;
        if(timeSinceLastAttack >= timeToCharge)
        {
            currentProjectile = Instantiate(chargeShot, attackPoint.position, Quaternion.identity);
        }
        else
        {
            currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        }
        timeSinceLastAttack = 0f;
        float distance = (currentEnemy.transform.position - transform.position).magnitude;
        Vector3 enemyPosition = currentEnemy.transform.position + (currentEnemy.GetComponent<Rigidbody>().velocity * distance / shootForce);
        Vector3 direction = (enemyPosition - transform.position).normalized;
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);

        TakeDamage(selfDamage);
    }
}
