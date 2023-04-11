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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            DamgeBoss(25f);
        }            
    }

    private void DamgeBoss(float dmg)
    {
        totBossHealth -= dmg;

        if(totBossHealth <= 0f)
        {
           totBossHealth = 100f; // Delete this add death 
        }
    }
}
