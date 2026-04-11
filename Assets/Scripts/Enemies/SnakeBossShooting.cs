using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBossShooting : SnakeBoss
{
    public bool alreadyAttacked;
    public GameObject currentEnemy;
    public float range;
    public GameObject projectile;
    public GameObject headProjectile;
    public float timeBetweenAttacks;
    public float headTimeBetweenAttacks;
    public float shootForce;
    public Collider[] enemies;
    public GameObject turret;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("Shoot", headTimeBetweenAttacks, headTimeBetweenAttacks);
    }

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
            turret.transform.LookAt(new Vector3(currentEnemy.transform.position.x, turret.transform.position.y, currentEnemy.transform.position.z));
        }
        if (currentEnemy != null && !alreadyAttacked)
        {
            Attack();
        }
        base.Update();
    }

    public void Attack()
    {
        if (!isHead && next != null)
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
    }

    public void Shoot()
    {
        if (isHead)
        {
            GameObject currentProjectile = Instantiate(headProjectile, transform.position, Quaternion.identity);

            if (shootForce != 0f)
            {
                currentProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.VelocityChange);
            }
        }
        if(next == null)
        {
            GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            if (shootForce != 0f)
            {
                currentProjectile.GetComponent<Rigidbody>().AddForce(transform.right * shootForce, ForceMode.VelocityChange);
            }
            currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            if (shootForce != 0f)
            {
                currentProjectile.GetComponent<Rigidbody>().AddForce(-transform.right * shootForce, ForceMode.VelocityChange);
            }
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
