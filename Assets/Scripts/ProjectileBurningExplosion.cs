using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBurningExplosion : Projectile
{
    public GameObject explosion;
    public float explosionRange;
    public float explosionDamage;
    public float burn;
    public float explosionBurn;
    public float burnDuration;
    public float explosionBurnDuration;
    public int explosionPierce;

    public override void OnTriggerEnter(Collider collider)
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange);
        foreach (Collider enemy in enemies)
        {
            if (explosionPierce > 0)
            {
                if (enemy.gameObject.GetComponent<Enemy>() != null)
                {
                    enemy.gameObject.GetComponent<Enemy>().TakeDamage(explosionDamage);
                    enemy.gameObject.GetComponent<Enemy>().Burn(explosionBurn, explosionBurnDuration);
                    explosionPierce -= 1;
                }
            }
        }
        collider.gameObject.GetComponent<Enemy>().Burn(burn, burnDuration);
        base.OnTriggerEnter(collider);
    }
}
