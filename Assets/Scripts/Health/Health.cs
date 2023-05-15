using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(IntangibilityController))]
public class Health : MonoBehaviour
{
    public static float totalHealth = 100f;
    public static float maximumHealth = 100f;
    private IntangibilityController _intangibilityController;
    private void Start()
    {
        _intangibilityController = GetComponent<IntangibilityController>();
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        //Some inanimate objects do not have their own scripts to attack the player. Here, the player checks for damage itself.
        string colliderTag = col.gameObject.tag;
        if(colliderTag == "Spikes" || colliderTag == "Enemy" || colliderTag == "FinalBoss")
        {
            PlayerActionController playerActionController = GetComponent<PlayerActionController>();
            if(playerActionController != null && !_intangibilityController.intangible) // Knockback when hit
            {
                Vector2 myPos = transform.position;
                //Vector2 sourcePoint = col.ClosestPoint(myPos);
                Vector2 sourcePoint = col.transform.position;
                Vector2 delta = myPos - sourcePoint;
                Vector2 knockbackVector = new Vector2(Mathf.Sign(delta.x) * 4f, 5f);
                playerActionController.Knockback(knockbackVector, true, 0.1f);
            }
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
            _intangibilityController.BecomeTemporarilyIntangible(0.75f, true);
            TakeDamage(damageAmount);
        }
    }
    public void TakeDamage(float damageAmount)
    {
        totalHealth -= damageAmount;
        if(totalHealth <= 0f)
        {
            totalHealth = 0f;
            //transform.position = Checkpoints.currCheckPoint;
            //FindObjectOfType<Respawn>().RespawnPlayer();
            totalHealth = 100f;
            Die();
        }
    }
    private void Die()
    {
        Animator animator = GetComponent<Animator>();
        if(animator != null)
        { 
            animator.SetTrigger("Die");
        }
        PlayerActionController playerActionController = GetComponent<PlayerActionController>();
        if(playerActionController != null)
        {
            playerActionController.paralyzed = true;
        }
        _intangibilityController.BecomeIntangible();
        LevelLoader loader = FindObjectOfType<LevelLoader>();
        if(loader == null)
        {
            //if there is no LevelLoader for some reason, we can reload but there will be no fade animation
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            loader.Reload();
        }
    }
}
