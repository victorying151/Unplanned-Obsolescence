using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTesting : MonoBehaviour
{
    public LogicManager logicManager;
    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
        GetComponent<Enemy>().health += logicManager.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
