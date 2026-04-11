using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExploding : Projectile
{
    public GameObject explosion;
    public float explosionRange;
    public float explosionDamage;
    public int explosionPierce;

    public override void OnTriggerEnter(Collider collider)
    {
        if (pierce > 0)
        {
            int ePierce = explosionPierce;
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange);
            foreach (Collider enemy in enemies)
            {
                if (ePierce > 0)
                {
                    Enemy currentExplosionTarget = enemy.gameObject.GetComponent<Enemy>();
                    if (currentExplosionTarget != null)
                    {
                        currentExplosionTarget.TakeDamage(explosionDamage);
                        ePierce -= 1;
                    }
                }

            }
        }
        base.OnTriggerEnter(collider);
    }
}
