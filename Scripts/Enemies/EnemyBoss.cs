using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyBoss : Enemy
{
    public List<float> thresholds;
    public List<GameObject> appearances;
    public float currentThreshold;
    public GameObject currentAppearance;

    protected override void Start()
    {
        currentThreshold = thresholds[0];
        thresholds.Remove(currentThreshold);
        currentAppearance = appearances[0];
        appearances.Remove(currentAppearance);
        base.Start();
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else if (health <= currentThreshold && gameObject)
        {
            currentThreshold = thresholds[0];
            thresholds.Remove(currentThreshold);
            currentAppearance.SetActive(false);
            currentAppearance = appearances[0];
            appearances.Remove(currentAppearance);
            currentAppearance.SetActive(true);
        }
    }

    public override void End()
    {
        EditorApplication.isPlaying = false;
    }
}
