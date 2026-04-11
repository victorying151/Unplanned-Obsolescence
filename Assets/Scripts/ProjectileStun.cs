using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStun : Projectile
{
    public float stunDuration;
    public float stunAmount = 1;
    public override void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<Enemy>()!= null)
        {
            collider.gameObject.GetComponent<Enemy>().Stun(stunAmount, stunDuration);
        }
        base.OnTriggerEnter(collider);
    }
}
