using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMortarOneZero : ProjectileExploding
{
    public bool exitFloor = false;
    public float bounce;
    public float stunDuration;

    public override void OnTriggerEnter(Collider collider)
    {
        if (exitFloor)
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
                        enemy.gameObject.GetComponent<Enemy>().Stun(1, stunDuration);
                    }
                    ePierce -= 1;
                }

            }
            if (collider.gameObject.GetComponent<Enemy>() != null)
            {
                collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
            pierce -= 1;
            if (pierce <= 0)
            {
                Delete();
            }
            mainProjectile.GetComponent<Rigidbody>().velocity = Vector3.up * bounce;
        }
        else
        {
            exitFloor = true;
        }
    }
}
