using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaserThreeZero : Projectile
{
    public GameObject split;

    public override void OnTriggerEnter(Collider collider)
    {
        GameObject current;
        current = Instantiate(split, transform.position, transform.rotation);

        base.OnTriggerEnter(collider);
    }
}
