using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public GameObject enemy;

    

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<GameObject>();
        //enemyHealth = 100f;
    }
    void Update()
    {
        if(enemyHealth <= 0f) 
        {
            Debug.Log("Enemy Died");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        Debug.Log("BatHit");
        if(col.tag == "Orb")
        {
            enemyHealth -= 60f;
        }
    }
    
   public void DamageEnemy(float dmg)
    {
        enemyHealth = enemyHealth - dmg;

        if(enemyHealth <= 0)
        {
            Debug.Log("Enemy Died");
            Destroy(gameObject);
        }

    }
}
