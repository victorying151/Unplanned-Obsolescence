using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Enemy
{
    public GameObject prev;
    public GameObject next;
    public bool isHead;
    public float offset;
    public GameObject head;
    public GameObject mid;
    public GameObject tail;
    public List<Vector3> pastPositions;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if(prev == null)
        {
            isHead = true;
            Travel(currentTarget);
            head.SetActive(true);
            mid.SetActive(false);
            tail.SetActive(false);
        }
        if(prev != null && next == null)
        {
            head.SetActive(false);
            mid.SetActive(false);
            tail.SetActive(true);
        }
        if(prev != null && next != null)
        {
            head.SetActive(false);
            mid.SetActive(true);
            tail.SetActive(false);
        }
        if (!isHead)
        {
            transform.position = prev.GetComponent<Snake>().pastPositions[0];
            transform.LookAt(prev.transform.position);
            currentTarget = prev.GetComponent<Enemy>().currentTarget;
        }
    }

    protected void FixedUpdate()
    {
        pastPositions.Add(transform.position);
        while(pastPositions.Count > offset/defaultSpeed)
        {
            pastPositions.RemoveAt(0);
        }
    }

    public override void Travel(Vector3 nextNode)
    {
        if (isHead)
        {
            base.Travel(nextNode);
        }
    }

    public override void TakeDamage(float damage)
    {
        SnakeArmoured prevArmour = null;
        if (prev) {
            prevArmour = prev.GetComponent<SnakeArmoured>();
        }
        SnakeArmoured nextArmour = null;
        if (next)
        {
            nextArmour = next.GetComponent<SnakeArmoured>();
        }
        if (!prevArmour && !nextArmour)
        {
            base.TakeDamage(damage);
        }
        else if (prevArmour && nextArmour)
        {
            prevArmour.TakeDamage(damage / 2);
            nextArmour.TakeDamage(damage / 2);
        }
        else if (prevArmour)
        {
            prevArmour.TakeDamage(damage);
        }
        else if (nextArmour)
        {
            nextArmour.TakeDamage(damage);
        }
    }

    public override void Die()
    {
        if (!gaveReward)
        {
            if (logicManager)
            {
                logicManager.money += reward;
            }
            if (voided != null)
            {
                GameObject spawn = Instantiate(voided, transform.position, Quaternion.identity);
                Snake spawnedSnake = spawn.GetComponent<Snake>();
                if (spawnedSnake)
                {
                    if (prev)
                    {
                        spawnedSnake.prev = prev;
                        prev.GetComponent<Snake>().next = spawn;
                    }
                    if (next)
                    {
                        spawnedSnake.next = next;
                        next.GetComponent<Snake>().prev = spawn;
                    }
                    if (isHead)
                    {
                        spawnedSnake.isHead = true;
                    }
                    spawnedSnake.pastPositions = pastPositions;
                }
            }
            gaveReward = true;
        }
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }    
}
