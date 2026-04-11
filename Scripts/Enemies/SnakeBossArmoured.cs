using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBossArmoured : SnakeBoss
{
    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (healthHolder)
        {
            healthHolder.SnakeDamage(damage);
        }
        if (health <= 0)
        {
            Die();
        }
    }
}
