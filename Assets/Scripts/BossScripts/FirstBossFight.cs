using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBossFight : MonoBehaviour
{
    public int health;
    public Slider bossHealthBar;

    private Rigidbody2D rb2D;
    private Animator animate;
    public float jumpForce;
    private float moveHorizontal;
    private float moveVertical;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bossHealthBar.value = health;

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

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
