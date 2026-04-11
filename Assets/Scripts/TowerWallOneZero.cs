using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWallOneZero : TowerWall
{
    public float threshold;

    protected override void Update()
    {
        if (health < threshold)
        {
            base.UpdateStore();
        }
    }

    public override void TakeDamage(float damage)
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        base.TakeDamage(damage);
    }
}
