using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectile;
    public Collider[] enemies;
    public GameObject currentEnemy;
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public Transform attackPoint;
    public float shootForce;
    public float range;
    public float health;
    public float selfDamage;
    public List<float> thresholds;
    public List<GameObject> appearances;
    public float currentThreshold;
    public GameObject currentAppearance;
    public LogicManager logicManager;
    public List<GameObject> upgrades;
    public List<int> upgradeCosts;
    public bool twozero;
    public bool threezero;
    public bool zerotwo;
    public bool zerothree;
    public int threezeropossible = 0;
    public int zerothreepossible = 0;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentThreshold = thresholds[0];
        thresholds.Remove(currentThreshold);
        currentAppearance = appearances[0];
        appearances.Remove(currentAppearance);
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(currentEnemy != null)
        {
            float distance = (currentEnemy.transform.position - transform.position).magnitude;
            if (distance > range)
            {
                currentEnemy = null;
            }
        }
        if(currentEnemy == null)
        {
            FindEnemy();
        }
        if (currentEnemy != null)
        {
            transform.LookAt(new Vector3(currentEnemy.transform.position.x, transform.position.y, currentEnemy.transform.position.z), Vector3.up);
        }
        if (currentEnemy != null && !alreadyAttacked)
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
        alreadyAttacked = true;
        Invoke("ResetAttack", timeBetweenAttacks);
        GameObject currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);

        if (shootForce != 0f)
        {
            float distance = (currentEnemy.transform.position - transform.position).magnitude;
            Vector3 enemyPosition = currentEnemy.transform.position + (currentEnemy.GetComponent<Rigidbody>().velocity * distance / shootForce);
            Vector3 direction = (enemyPosition - transform.position).normalized;
            currentProjectile.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.VelocityChange);
        }
        TakeDamage(selfDamage);
    }

    public void FindEnemy()
    {
        enemies = Physics.OverlapSphere(transform.position, range);
        if (enemies.Length == 0)
        {
            currentEnemy = null;
        }
        else
        {
            foreach(Collider enemy in enemies)
            {
                Enemy target = enemy.GetComponent<Enemy>();
                if (target)
                {
                    if (currentEnemy == null)
                    {
                        currentEnemy = enemy.gameObject;
                    }
                    else if (target.distance > currentEnemy.GetComponent<Enemy>().distance)
                    {
                        currentEnemy = enemy.gameObject;
                    }
                }
            }
        }
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else if (health <= currentThreshold && gameObject)
        {
            currentThreshold = thresholds[0];
            thresholds.Remove(currentThreshold);
            currentAppearance.SetActive(false);
            currentAppearance = appearances[0];
            appearances.Remove(currentAppearance);
            currentAppearance.SetActive(true);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    
}
