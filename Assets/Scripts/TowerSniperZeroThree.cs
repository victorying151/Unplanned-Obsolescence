using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSniperZeroThree : Tower
{
    public float threshold;

    protected override void Update()
    {
        if (health < threshold)
        {
            base.Update();
        }
    }
}
