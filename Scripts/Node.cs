using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int order;
    public Transform nextNode;

    void OnTriggerEnter(Collider collider)
    {
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            if (nextNode != null)
            {
                enemy.Travel(nextNode.position);
            }
            else
            {
                enemy.End();
            }
        }

        ProjectileSpawningEnemy projectile = collider.gameObject.GetComponent<ProjectileSpawningEnemy>();
        if (projectile)
        {
            if (nextNode != null)
            {
                projectile.Travel(nextNode.position);
            }
        }
    }

}
