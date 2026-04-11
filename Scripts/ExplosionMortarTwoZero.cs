using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMortarTwoZero : MonoBehaviour
{
    public GameObject explosion;
    public float explosionRange;
    public int pierce;
    public float explosionDamage;

    public void Explode()
    {
        int ePierce = pierce;
        Instantiate(explosion, transform.position, Quaternion.identity);
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
        Destroy(gameObject);
    }
}
