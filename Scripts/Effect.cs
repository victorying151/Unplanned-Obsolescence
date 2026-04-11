using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        if (target)
        {
            transform.position = target.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
