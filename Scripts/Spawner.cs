using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float delay;
    public Transform firstNode;
    public GameObject spawn;
    public float interval;
    public int count;

    protected virtual void Start()
    {
        InvokeRepeating("Spawn", delay, interval);
    }

    public virtual void Spawn()
    {
        if (count > 0)
        {
            GameObject current = Instantiate(spawn, transform.position, Quaternion.identity);
            current.GetComponent<Enemy>().Travel(firstNode.position);
            count -= 1;
        }
    }
}
