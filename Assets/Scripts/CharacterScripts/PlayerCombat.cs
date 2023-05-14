using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform swordAttackPoint;
    public float swordAttackRange = 0.5f;
    void Update()
    {
    }

    public void Attack()
    {
        //Detect range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordAttackPoint.position, swordAttackRange);
        //Damage enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.transform.IsChildOf(transform) || transform.IsChildOf(enemy.transform))
            {
                continue;
            }
            BossHealth bossHealth = enemy.GetComponent<BossHealth>();
            if(bossHealth != null)
            {
                bossHealth.DamageBoss(5f);
                return;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(swordAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(swordAttackPoint.position, swordAttackRange);
    }
}
