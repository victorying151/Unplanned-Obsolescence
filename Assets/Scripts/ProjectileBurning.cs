using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBurning : Projectile
{
    public float burn;
    public float duration;

    public override void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.GetComponent<Enemy>().Burn(burn, duration);
        base.OnTriggerEnter(collider);
    }
}
