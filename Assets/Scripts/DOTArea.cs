using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTArea : MonoBehaviour
{
    public float DOT;

    private void OnTriggerStay(Collider target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(DOT * Time.deltaTime);
        }
    }
}
