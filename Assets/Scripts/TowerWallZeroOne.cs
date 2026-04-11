using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWallZeroOne : TowerWall
{
    public List<Tower> towers;
    public float healInterval;
    
    protected override void Start()
    {
        InvokeRepeating("Heal", 0f, healInterval);
        base.Start();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Tower>() != null)
        {
            towers.Add(collider.GetComponent<Tower>());
        }
    }

    public void Heal()
    {
        for(int i = towers.Count -1; i>=0; i--)
        {
            if(towers[i] != null)
            {
                GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                currentProjectile.GetComponent<HomingOntoObject>().target = towers[i].gameObject;
                TakeDamage(selfDamage);
            }
            else
            {
                towers.RemoveAt(i);
            }
        }
    }
}
