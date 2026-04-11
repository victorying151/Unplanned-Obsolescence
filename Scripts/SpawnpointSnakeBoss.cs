using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointSnakeBoss : Spawner
{
    public GameObject healthHolder;
    public List<GameObject> parts;
    public GameObject prevCurrent;
    public float delayBetweenParts;

    protected override void Start()
    {
        Invoke("Spawn", delay);
    }

    public override void Spawn()
    {
        StartCoroutine("Summon");
        GameObject current = Instantiate(healthHolder, transform.position, Quaternion.identity);
    }

    IEnumerator Summon()
    {
        for (int i = 0; i <= parts.Count - 1; i++)
        {
            GameObject current = Instantiate(parts[i], transform.position, Quaternion.identity);
            if (i == 0)
            {
                current.GetComponent<Enemy>().Travel(firstNode.position);
            }
            if (i != 0)
            {
                if(prevCurrent != null)
                {
                    current.GetComponent<SnakeBoss>().prev = prevCurrent;
                    prevCurrent.GetComponent<SnakeBoss>().next = current;
                }
            }
            prevCurrent = current;
            yield return new WaitForSeconds(delayBetweenParts);
        }
    }
}
