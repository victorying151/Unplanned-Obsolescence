using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeArmoured : Snake
{
    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
}
