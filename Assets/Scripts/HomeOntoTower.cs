using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeOntoTower : MonoBehaviour
{
    public float range;
    public float homeSpeed;
    public GameObject[] enemies;
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
        float distance = 0f;
        float minDistance = 100000f;
        enemies = GameObject.FindGameObjectsWithTag("Tower");
        if (enemies.Length == 0)
        {
            currentEnemy = null;
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                distance = (enemy.transform.position - transform.position).magnitude;
                if (distance <= range)
                {
                    if (currentEnemy == null)
                    {
                        currentEnemy = enemy;
                        minDistance = distance;
                    }
                    else if (minDistance > distance)
                    {
                        currentEnemy = enemy;
                        minDistance = distance;
                    }
                }
            }
        }
    }
}
