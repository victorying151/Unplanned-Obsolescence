using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBoss : EnemyBoss
{
    public override void RecalculateSpeed()
    {
        if (stuns.Count == 0)
        {
            currentStun = 0;
            speed = defaultSpeed;
        }
        else
        {
            foreach (Vector2 stun in stuns)
            {
                if (stun.x > currentStun)
                {
                    currentStun = stun.x;
                }
            }
            speed = defaultSpeed * Mathf.Max(0,(1 - currentStun/2));
        }
        Travel(currentTarget);
    }
}
