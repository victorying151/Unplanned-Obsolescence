using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    public Vector3 expandSpeed;
    public float stopTime;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay<=0){
            stopTime -= Time.deltaTime;
            if(stopTime>=0){
                transform.localScale += expandSpeed * Time.deltaTime;
            }
        }
    }
}
