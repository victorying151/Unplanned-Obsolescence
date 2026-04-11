using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplodingStun : Projectile
{
    public GameObject explosion;
    public float explosionRange;
    public float explosionDamage;
    public float stunDuration;
    public int explosionPierce;
    public float stunAmount = 1;

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
                    if (enemy.gameObject.GetComponent<Enemy>() != null)
                    {
                        enemy.gameObject.GetComponent<Enemy>().TakeDamage(explosionDamage);
                        enemy.gameObject.GetComponent<Enemy>().Stun(stunAmount, stunDuration);
                        ePierce -= 1;
                    }
                }
            }
        }
        
        base.OnTriggerEnter(collider);
    }
}
