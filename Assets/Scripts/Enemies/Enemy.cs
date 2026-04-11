using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float distance;
    public float speed;
    public float defaultSpeed;
    public Vector3 currentTarget;
    public float health;
    public LogicManager logicManager;
    public int reward;
    public Vector3 intendedVelocity;
    public float stunnedFor;
    public List<Vector2> stuns;
    public float currentStun;
    public List<Vector2> burns;
    public GameObject burnEffect;
    public bool gaveReward = false;
    public GameObject voided;
    public float stunResistance;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        defaultSpeed = speed;
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        distance += speed * Time.deltaTime;
        for(int i = burns.Count-1; i>=0; i--)
        {
            Vector2 burn = burns[i];
            TakeDamage(burn.x * Time.deltaTime);
            burn.y -= Time.deltaTime;
            if (burn.y <= 0)
            {
                burns.RemoveAt(i);
                if(burns.Count == 0)
                {
                    Destroy(burnEffect);
                }
            }
            else
            {
                burns[i] = burn;
            }
        }
        for(int i = stuns.Count-1; i>=0; i--)
        {
            Vector2 stun = stuns[i];
            stun.y -= Time.deltaTime;
            if(stun.y <= 0)
            {
                stuns.RemoveAt(i);
                RecalculateSpeed();
            }
            else
            {
                stuns[i] = stun;
            }
        }
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if(health<= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if (!gaveReward)
        {
            if (logicManager)
            {
                logicManager.money += reward;
            }
            if(voided != null)
            {
                Instantiate(voided, transform.position, Quaternion.identity);
            }
            gaveReward = true;
        }
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Travel(Vector3 nextNode)
    {
        currentTarget = nextNode;
        Vector3 direction = (nextNode - transform.position).normalized;
        transform.LookAt(new Vector3(nextNode.x, transform.position.y, nextNode.z));
        GetComponent<Rigidbody>().velocity = direction * speed;
    }

    public virtual void End()
    {
        Destroy(gameObject);
    }

    public void Burn(float burnAmount, float duration)
    {
        burns.Add(new Vector2(burnAmount, duration));
        if(burnEffect == null)
        {
            burnEffect = Instantiate(logicManager.burnEffect, transform.position, Quaternion.identity);
            burnEffect.GetComponent<Effect>().target = gameObject;
        }
    }

    public virtual void Stun(float amount, float duration)
    {
        stuns.Add(new Vector2(amount, duration));
        RecalculateSpeed();
    }

    public virtual void RecalculateSpeed()
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
            speed = defaultSpeed * Mathf.Max(0, (1 - currentStun * (1 - stunResistance)));
        }
        Travel(currentTarget);
    }

    /*
        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.layer == 10)
            {
                if (collider.gameObject.GetComponent<Node>().nextNode != null)
                {
                    Travel(collider.gameObject.GetComponent<Node>().nextNode.position);
                }
                else
                {
                    End();
                }
            }
        }
    */
}
