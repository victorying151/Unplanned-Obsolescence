using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBoss : EnemyBoss
{
    public bool alreadyAttacked;
    public GameObject currentEnemy;
    public float range;
    public float range2;
    public GameObject projectile;
    public GameObject sniperProjectile;
    public float timeBetweenAttacks;
    public float timeBetweenTwins;
    public float shootForce;
    public Collider[] enemies;
    public bool twin;
    public Transform snipePoint;
    public Transform attackPoint;
    public Transform attackPoint2;
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
        GameObject currentProjectile;
        float distance = (currentEnemy.transform.position - transform.position).magnitude;
        Vector3 enemyPosition = currentEnemy.transform.position;
        Vector3 direction = (enemyPosition - transform.position).normalized;
        if(distance <= range)
        {
            Invoke("ResetAttack", timeBetweenTwins);
            twin = !twin;
            if (twin)
            {
                currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
                currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
            }
            else
            {
                currentProjectile = Instantiate(projectile, attackPoint2.position, Quaternion.identity);
                currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
            }
            
        }
        else
        {
            Invoke("ResetAttack", timeBetweenAttacks);
            currentProjectile = Instantiate(sniperProjectile, snipePoint.position, Quaternion.identity);
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
            if (currentEnemy == null)
            {
                foreach (Collider enemy in enemies)
                {
                    Tower target = enemy.GetComponent<Tower>();
                    if (target)
                    {
                        distance = (enemy.transform.position - transform.position).magnitude;
                        if (distance <= range2)
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
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public override void Travel(Vector3 nextNode)
    {
        currentTarget = nextNode;
        Vector3 direction = (nextNode - transform.position).normalized;
        GetComponent<Rigidbody>().velocity = direction * speed;
    }
}
