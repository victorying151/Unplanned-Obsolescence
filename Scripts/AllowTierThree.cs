using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowTierThree : MonoBehaviour
{
    public bool allowThreeZero;
    public bool allowZeroThree;
    public List<Tower> towers;

    public void OnTriggerEnter(Collider collider)
    {
        Tower tower = collider.GetComponent<Tower>();
        towers.Add(tower);
        if (tower != null)
        {
            if (allowThreeZero)
            {
                tower.threezeropossible += 1;
            }
            if (allowZeroThree)
            {
                tower.zerothreepossible += 1;
            }
        }
    }

    public void OnDestroy()
    {
        for(int i = towers.Count - 1; i>=0; i--)
        {
            if (towers[i] != null)
            {
                if (allowThreeZero)
                {
                    towers[i].threezeropossible -= 1;
                }
                if (allowZeroThree)
                {
                    towers[i].zerothreepossible -= 1;
                }
            }
        }
    }
}
