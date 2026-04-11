using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForwards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;

        if (velocity != Vector3.zero)
        {
            transform.LookAt(transform.position + velocity);
        }
    }
}
