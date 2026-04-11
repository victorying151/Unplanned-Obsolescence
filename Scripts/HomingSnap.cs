using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSnap : MonoBehaviour
{
    public GameObject currentEnemy;
    public float delay;
    public float force;
    public float range;
    public float interval;
    public Collider[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        if(interval == 0)
        {
            Invoke("FindEnemy", delay);
        }
        else
        {
            InvokeRepeating("FindEnemy", delay, interval);
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
        if (currentEnemy)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Vector3 direction = (currentEnemy.transform.position - transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(force * direction, ForceMode.VelocityChange);
        }
        else if(interval == 0)
        {
            Invoke("FindEnemy", delay);
        }
    }
}
