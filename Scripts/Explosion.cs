using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionRange;
    public float explosionDamage;
    public int explosionPierce;

    void Start()
    {
        int ePierce = explosionPierce;
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange);
        foreach (Collider enemy in enemies)
        {
            if (ePierce > 0)
            {
                Enemy current = enemy.gameObject.GetComponent<Enemy>();
                if (current != null)
                {
                    current.TakeDamage(explosionDamage);
                    ePierce -= 1;
                }
            }

        }
    }
}
