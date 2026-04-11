using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingForwards : Enemy
{
    public GameObject projectile;
    public float timeBetweenAttacks;
    public float shootForce;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("Attack", timeBetweenAttacks, timeBetweenAttacks);
    }

    public void Attack()
    {
        GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

        if (shootForce != 0f)
        {
            currentProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.VelocityChange);
        }
    }
}
