using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerDodge))]
public class CharacterAnimations : MonoBehaviour
{
    private Animator animate;
    private PlayerDodge moveHorizontal;
    private bool facingRight = true;

    void Start()
    {
        moveHorizontal = gameObject.GetComponent<PlayerDodge>();
        animate = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animate.SetFloat("Speed", Mathf.Abs(moveHorizontal.animationInput));

        if(moveHorizontal.animationInput >  0 && !facingRight) {
            flip();
        } else if(moveHorizontal.animationInput <  0 && facingRight) {
            flip();
        }
    }

    void flip() {
        facingRight = !facingRight;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

}
