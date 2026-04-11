using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public float range;
    public float homeSpeed;
    public Collider[] enemies;
    public GameObject currentEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemy == null)
        {
            FindEnemy();
        }
        if (currentEnemy != null)
        {
            transform.LookAt(currentEnemy.transform, Vector3.up);
            Vector3 direction = (currentEnemy.transform.position - transform.position).normalized;
            GetComponent<Rigidbody>().velocity += direction * homeSpeed * Time.deltaTime;
        }
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
            foreach (Collider enemy in enemies)
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
}
