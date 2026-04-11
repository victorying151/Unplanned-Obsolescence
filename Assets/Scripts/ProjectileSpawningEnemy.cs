using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawningEnemy : MonoBehaviour
{
    public float delay;
    public Vector3 nextNode;
    public GameObject enemy;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", delay);
    }

    public void Spawn()
    {
        GameObject current = Instantiate(enemy, transform.position, Quaternion.identity);
        current.GetComponent<Enemy>().Travel(nextNode);
        current.GetComponent<Enemy>().distance = distance;
        Destroy(gameObject);
    }

    public void Travel(Vector3 nextOverrideNode)
    {
        GameObject current = Instantiate(enemy, transform.position, Quaternion.identity);
        current.GetComponent<Enemy>().Travel(nextOverrideNode);
        current.GetComponent<Enemy>().distance = distance;
        Destroy(gameObject);
    }
}
