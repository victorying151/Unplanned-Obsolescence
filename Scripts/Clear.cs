using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    public float time;
    public bool explode;
    public float explosionRange;
    public float explosionDamage;
    public int explosionPierce;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", time);
    }

    // Update is called once per frame
    private void Destroy()
    {
        if(explode == true)
        {
            int ePierce = explosionPierce;
            Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange);
            foreach (Collider enemy in enemies)
            {
                if (ePierce > 0)
                {
                    if (enemy.gameObject.GetComponent<Enemy>() != null)
                    {
                        enemy.gameObject.GetComponent<Enemy>().TakeDamage(explosionDamage);
                    }
                    ePierce -= 1;
                }

            }
        }
        Destroy(gameObject);
    }
}
