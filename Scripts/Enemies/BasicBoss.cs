using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoss : EnemyBoss
{
    public GameObject spawn;
    public int spawnCount;
    public float noise;
    public override void Die()
    {
        if (!gaveReward)
        {
            for(int i = 0; i<spawnCount; i++)
            {
                Vector3 offset = Random.insideUnitSphere * noise;
                GameObject enemy = Instantiate(spawn, transform.position + new Vector3(offset.x, 0f, offset.z), Quaternion.identity);
                enemy.GetComponent<Enemy>().Travel(currentTarget);
                enemy.GetComponent<Enemy>().distance = distance;
            }
            logicManager.money += reward;
            gaveReward = true;
        }

        Destroy(gameObject);
    }
}
