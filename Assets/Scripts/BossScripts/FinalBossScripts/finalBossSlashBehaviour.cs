using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBossSlashBehaviour : StateMachineBehaviour
{
     public float timer;
    public float minTime;
    public float maxTime;

    private Vector2 playerPos;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        timer = Random.Range(minTime, maxTime);
        //animator.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3f, ForceMode2D.Impulse);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0) 
        {
            animator.SetTrigger("idle");
        } else {
            timer -= Time.deltaTime;
        }

        Vector2 target = new Vector2(playerPos.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
