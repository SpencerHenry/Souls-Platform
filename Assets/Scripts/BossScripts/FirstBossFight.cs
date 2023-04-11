using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBossFight : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animate;
    public float jumpForce;
    private float moveHorizontal;
    private float moveVertical;
    public bool facingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animate = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float myX = transform.position.x;
        float playerX = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x;
        moveHorizontal = playerX - myX;

        if(moveHorizontal >  0 && !facingRight) {
            flip();
        } else if(moveHorizontal <  0 && facingRight) {
            flip();
        }
    }

    void FixedUpdate() {


        if(animate.GetCurrentAnimatorStateInfo(0).IsTag("jumpAnimation")) {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        
        }
    }

    void flip() {
        facingRight = !facingRight;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

}
