using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMagicThreeZero : MonoBehaviour
{
    public GameObject voidling;

    private void OnTriggerEnter(Collider target)
    {
        if(target.GetComponent<Enemy>() != null)
        {
            target.GetComponent<Enemy>().voided = voidling;
        }
    }


}
