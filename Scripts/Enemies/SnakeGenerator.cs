using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGenerator : Snake
{
    public float delay;
    public GameObject spawn;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("Spawn", delay, delay);
    }

    public void Spawn()
    {
        if (!next)
        {
            GameObject current = Instantiate(spawn, transform.position, transform.rotation);
            current.GetComponent<Snake>().prev = gameObject;
            next = current;
            current.GetComponent<Snake>().reward = 0;
        }
    }
}
