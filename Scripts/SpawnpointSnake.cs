using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointSnake : Spawner
{
    public List<GameObject> parts;
    public GameObject prevCurrent;
    public float delayBetweenParts;

    public override void Spawn()
    {
        if (count > 0)
        {
            StartCoroutine("Summon");
            count -= 1;
        }
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
                    current.GetComponent<Snake>().prev = prevCurrent;
                    prevCurrent.GetComponent<Snake>().next = current;
                }
            }
            prevCurrent = current;
            yield return new WaitForSeconds(delayBetweenParts);
        }
    }
}
