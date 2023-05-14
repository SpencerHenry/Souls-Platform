using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public static float totBossHealth = 100f;
    public static float maximumHealth = 100f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Sword") // can add more when more implemented
        {
            
        }

    }

    private void Start()
    {
        string healthTag = gameObject.tag;
        if(healthTag == "NoDamage" ) {

        } else {
            totBossHealth = 100f;
        }
    
        
        
    }

    private void Update()
    {        
    }

    public void DamageBoss(float dmg)
    {
        totBossHealth -= dmg;

        if(totBossHealth <= 0f)
        {
            totBossHealth = 0f;
            //did this to fix a bug with having two BossHealth Scripts on an object. 
            //I need two on an object in order to not take damage from the boss but still be able to damage it
            GameObject go = GameObject.Find ("FinalBoss");
            if (go){
                Destroy (go.gameObject);
            
            } else {
                Destroy(gameObject);
            }
        }
    }
}
