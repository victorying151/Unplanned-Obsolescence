using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMortarZeroOne : ProjectileStun
{
    public bool exitFloor = false;

    public override void OnTriggerEnter(Collider collider)
    {
        if(exitFloor)
        {
            if (collider.gameObject.GetComponent<Enemy>() != null)
            {
                collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                collider.gameObject.GetComponent<Enemy>().Stun(1, stunDuration);
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
