using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float slow;
    public List<Enemy> enemies;

    void Start()
    {
        InvokeRepeating("Stun", 0f, 0.1f);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.GetComponent<Enemy>())
        {
            enemies.Add(target.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider target){
        if (enemies.Contains(target.GetComponent<Enemy>()))
        {
            enemies.Remove(target.GetComponent<Enemy>());
        }
    }

    public void Stun()
    {
        for(int i = enemies.Count - 1; i>=0; i--)
        {
            if(enemies[i] != null)
            {
                enemies[i].Stun(slow, 0.1f);
            }
            else
            {
                enemies.RemoveAt(i);
            }
        }
    }
}
