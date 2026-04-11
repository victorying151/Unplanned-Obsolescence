using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public float timeBetween;
    public float delay;
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, timeBetween);
    }

    public void Spawn()
    {
        Instantiate(spawn, transform.position, transform.rotation);
    }
}
