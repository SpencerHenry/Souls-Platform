using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(IntangibilityController))]
public class Health : MonoBehaviour
{
    public static float totalHealth = 100f;
    public static float maximumHealth = 100f;
    //public HealthBar healthBar;
    private IntangibilityController _intangibilityController;
    private void Start()
    {
        _intangibilityController = GetComponent<IntangibilityController>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Some inanimate objects do not have their own scripts to attack the player. Here, the player checks for damage itself.
        string colliderTag = col.gameObject.tag;
        if(colliderTag == "Spikes" || colliderTag == "Enemy")
        {
            AttemptToDamage(30f);
        }

        if(colliderTag == "FirstBoss")
        {
            AttemptToDamage(20f);
        }

        if(colliderTag == "FallDetector")
        {
            TakeDamage(Health.totalHealth);//dead
        }
    }
    public void AttemptToDamage(float damageAmount)
    {
        if(!_intangibilityController.intangible)
        {
            TakeDamage(damageAmount);
        }
    }
    public void TakeDamage(float damageAmount)
    {
        totalHealth -= damageAmount;
        if(totalHealth <= 0f)
        {
            totalHealth = 0f;
            FindObjectOfType<Respawn>().RespawnPlayer();
            totalHealth = 100f;
        }
    }
}
