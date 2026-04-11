using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAdvanced : Snake
{
    public bool alreadyAttacked;
    public GameObject currentEnemy;
    public float range;
    public Collider[] enemies;
    public GameObject projectile;
    public float timeBetweenAttacks;
    public float shootForce;
    // Start is called before the first frame update

    protected override void Update()
    {
        if (currentEnemy != null)
        {
            float distance = (currentEnemy.transform.position - transform.position).magnitude;
            if (distance > range)
            {
                currentEnemy = null;
            }
        }
        if (currentEnemy == null)
        {
            FindEnemy();
        }
        if (currentEnemy != null)
        {
            transform.LookAt(currentEnemy.transform.position);
        }
        if (currentEnemy != null && !alreadyAttacked)
        {
            Attack();
        }
        base.Update();
    }

    public void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

        if (shootForce != 0f)
        {
            float distance = (currentEnemy.transform.position - transform.position).magnitude;
            Vector3 enemyPosition = currentEnemy.transform.position;
            Vector3 direction = (enemyPosition - transform.position).normalized;
            currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        }
    }

    public void FindEnemy()
    {
        float distance = 0f;
        float closestDistance = range + 100f;
        enemies = Physics.OverlapSphere(transform.position, range);
        if (enemies.Length == 0)
        {
            currentEnemy = null;
        }
        else
        {
            foreach (Collider enemy in enemies)
            {
                Tower target = enemy.GetComponent<Tower>();
                if (target)
                {
                    distance = (enemy.transform.position - transform.position).magnitude;
                    if (distance <= range)
                    {
                        if (currentEnemy == null)
                        {
                            currentEnemy = enemy.gameObject;
                            closestDistance = distance;
                        }
                        else if (distance < closestDistance)
                        {
                            currentEnemy = enemy.gameObject;
                            closestDistance = distance;
                        }
                    }
                }
            }
        }
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
