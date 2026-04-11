using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBoss : EnemyBoss
{
    public GameObject prev;
    public GameObject next;
    public bool isHead;
    public float offset;
    public GameObject head;
    public GameObject mid;
    public GameObject tail;
    public SnakeBossHealth healthHolder;
    public List<Vector3> pastPositions;

    protected override void Start()
    {
        base.Start();
        healthHolder = GameObject.FindGameObjectWithTag("SnakeBossHealthHolder").GetComponent<SnakeBossHealth>();
        healthHolder.health += health;
    }

    protected override void Update()
    {
        base.Update();
        if (prev == null)
        {
            isHead = true;
            Travel(currentTarget);
            head.SetActive(true);
            mid.SetActive(false);
            tail.SetActive(false);
        }
        if (prev != null && next == null)
        {
            head.SetActive(false);
            mid.SetActive(false);
            tail.SetActive(true);
        }
        if (prev != null && next != null)
        {
            head.SetActive(false);
            mid.SetActive(true);
            tail.SetActive(false);
        }
        if (!isHead)
        {
            transform.position = prev.GetComponent<SnakeBoss>().pastPositions[0];
            transform.LookAt(prev.transform.position);
            currentTarget = prev.GetComponent<SnakeBoss>().currentTarget;
        }
    }

    protected void FixedUpdate()
    {
        pastPositions.Add(transform.position);
        while (pastPositions.Count > offset / defaultSpeed)
        {
            pastPositions.RemoveAt(0);
        }
    }

    public override void Travel(Vector3 nextNode)
    {
        if (isHead)
        {
            currentTarget = nextNode;
            Vector3 direction = (nextNode - transform.position).normalized;
            transform.LookAt(new Vector3(nextNode.x, transform.position.y, nextNode.z));
            GetComponent<Rigidbody>().velocity = direction * speed;
        }
    }

    public override void TakeDamage(float damage)
    {
        SnakeBossArmoured prevArmour = null;
        if (prev)
        {
            prevArmour = prev.GetComponent<SnakeBossArmoured>();
        }
        SnakeBossArmoured nextArmour = null;
        if (next)
        {
            nextArmour = next.GetComponent<SnakeBossArmoured>();
        }
        if (!prevArmour && !nextArmour)
        {
            base.TakeDamage(damage);
            if (healthHolder)
            {
                healthHolder.SnakeDamage(damage);
            }
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
        base.Die();
    }
}
