using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMortar : ProjectileExploding
{
    public bool exitFloor = false;

    public override void OnTriggerEnter(Collider collider)
    {
        if(exitFloor)
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
        }
        else
        {
            exitFloor = true;
        }
    }
}
