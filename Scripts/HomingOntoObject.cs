using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingOntoObject : MonoBehaviour
{
    public float homeSpeed;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform, Vector3.up);
            Vector3 direction = (target.transform.position - transform.position).normalized;
            GetComponent<Rigidbody>().velocity += direction * homeSpeed * Time.deltaTime;
        }
    }
}
