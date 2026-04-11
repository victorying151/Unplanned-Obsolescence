using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMortarTwoZero : ProjectileExploding
{
    public bool exitFloor = false;
    public float bounce;
    public List<GameObject> explosions = new List<GameObject>();
    public Homing homing;

    public override void OnTriggerEnter(Collider collider)
    {
        if (exitFloor)
        {
            homing.enabled = true;
            GameObject currentExplosion = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosions.Add(currentExplosion);
            pierce -= 1;
            
            if (pierce <= 0)
            {
                foreach(GameObject ex in explosions)
                {
                    ex.GetComponent<ExplosionMortarTwoZero>().Explode();
                }
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
