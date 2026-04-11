using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBossHealth : Enemy
{
    public SnakeBoss[] snakes;
    protected override void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
        logicManager.healthBar.boss = this;
    }

    protected override void Update()
    {
        snakes = Object.FindObjectsOfType<SnakeBoss>();
        if(snakes.Length == 0)
        {
            Destroy(gameObject);
        }
    }

    public override void Travel(Vector3 nextNode) { }

    public override void TakeDamage(float damage) { }

    public override void Die() 
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    public void SnakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }
}
