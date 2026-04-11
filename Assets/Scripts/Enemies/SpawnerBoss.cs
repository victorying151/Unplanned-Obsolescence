using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : EnemyBoss
{
    public float sideDelay;
    public float mainDelay;
    public float secondPhaseHealth;
    public float sideShootForce;
    public int sideCount;
    public float sideShootForceVariance;
    public Transform sidePoint1;
    public Transform sidePoint2;
    public bool twin;
    public Transform mainPoint;
    public Transform secondPhasePoint;
    public List<Transform> secondPhaseAttackPoints;
    public float secondPhaseShotDelay;
    public float secondShootForce;
    public GameObject sideProjectile;
    public GameObject mainProjectie;
    public GameObject shootingProjectile;
    public GameObject shot;
    public GameObject currentProjectile;
    public GameObject homingProjectile;
    public bool inSecondPhase;
    public GameObject healthBar;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("SideCannon", sideDelay, sideDelay);
        InvokeRepeating("MainSpawn", mainDelay, mainDelay);
        logicManager.healthBar.boss = this;
    }

    public void SideCannon()
    {
        StartCoroutine("SideSpawn");
    }

    public void MainSpawn()
    {
        currentProjectile = Instantiate(mainProjectie, mainPoint.position, Quaternion.identity);
        currentProjectile.GetComponent<Enemy>().Travel(currentTarget);
        currentProjectile.GetComponent<Enemy>().distance += distance;
        //if (health <= secondPhaseHealth)
        //{
        //    currentProjectile.GetComponent<Enemy>().health = currentProjectile.GetComponent<Enemy>().health * 2;
        //}
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if(health <= secondPhaseHealth && !inSecondPhase)
        {
            inSecondPhase = true;
            for(int i = 0; i< secondPhaseAttackPoints.Count; i++)
            {
                currentProjectile = Instantiate(shootingProjectile, secondPhasePoint.position, Quaternion.identity);
                currentProjectile.GetComponent<Rigidbody>().AddForce(secondShootForce * (secondPhaseAttackPoints[i].position - transform.position), ForceMode.VelocityChange);
                currentProjectile.GetComponent<ProjectileSpawningEnemy>().nextNode = currentTarget;
                currentProjectile.GetComponent<ProjectileSpawningEnemy>().distance = distance;
            }
            InvokeRepeating("Shoot", 0f, secondPhaseShotDelay);
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < secondPhaseAttackPoints.Count; i++)
        {
            currentProjectile = Instantiate(shot, secondPhasePoint.position, Quaternion.identity);
            currentProjectile.GetComponent<Rigidbody>().AddForce(secondShootForce * (secondPhaseAttackPoints[i].position - transform.position), ForceMode.VelocityChange);
        }
    }

    IEnumerator SideSpawn()
    {
        for (int i = 0; i < sideCount; i++){

            if (twin)
            {
                currentProjectile = Instantiate(sideProjectile, sidePoint1.position, Quaternion.identity);
            }
            else
            {
                currentProjectile = Instantiate(sideProjectile, sidePoint2.position, Quaternion.identity);
            }
            currentProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * (sideShootForce + Random.Range(-sideShootForceVariance, sideShootForceVariance)), ForceMode.VelocityChange);
            currentProjectile.GetComponent<ProjectileSpawningEnemy>().nextNode = currentTarget;
            currentProjectile.GetComponent<ProjectileSpawningEnemy>().distance = distance;
            if (twin)
            {
                currentProjectile = Instantiate(homingProjectile, sidePoint1.position, Quaternion.identity);
            }
            else
            {
                currentProjectile = Instantiate(homingProjectile, sidePoint2.position, Quaternion.identity);
            }
            currentProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * (sideShootForce + Random.Range(-sideShootForceVariance, sideShootForceVariance)), ForceMode.VelocityChange);
            twin = !twin;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
