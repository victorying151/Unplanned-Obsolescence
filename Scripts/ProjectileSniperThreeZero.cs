using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSniperThreeZero : Projectile
{
    public GameObject split;
    public float splitForce;
    public List<Transform> points;

    public override void OnTriggerEnter(Collider collider)
    {
        GameObject current;
        Vector3 direction;

        foreach(Transform point in points)
        {
            current = Instantiate(split, transform.position, Quaternion.identity);
            direction = (point.position - transform.position).normalized;
            current.GetComponent<Rigidbody>().AddForce(direction * splitForce, ForceMode.VelocityChange);
        }

        base.OnTriggerEnter(collider);
    }
}
