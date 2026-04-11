using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // DONT PUT ON PROJECTILE PUT ON THE HITSCANNER
    public float damage;
    public int pierce;
    public GameObject mainProjectile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.GetComponent<Tower>().TakeDamage(damage);
        pierce -= 1;
        if (pierce <= 0)
        {
            Delete();
        }
    }

    public virtual void Delete()
    {
        Destroy(mainProjectile);
    }
}
