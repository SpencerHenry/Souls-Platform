using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<GameObject>();
        enemyHealth = 100f;
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.tag == "Orb")
        {
        enemyHealth -= 60f;
        }

        if(enemyHealth <= 0)
        {
            Destroy(enemy);
        }
    }
}
