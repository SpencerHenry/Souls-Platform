using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
[RequireComponent(typeof(IntangibilityController))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDodge : MonoBehaviour
{
    public bool dodgeEnabled = true;
    public bool walkEnabled = true;
    public float dodgeCooldownLimit = 0.5f;
    public float dodgeCooldownRemaining = 0f;
    public int dodgesInAirLimit = 1;
    public int dodgesInAirPerformed = 0;
    public bool debugShowDodgeFrames = false;
    public float intangibilityWindow = 0.25f;
    public float dodgeInitialSpeed = 12f;
    public float dodgeSpeedBleedDelay = 0.25f;
    public float dodgeSpeedBleedDuration = 0.25f;
    public float dodgeSpeedBleedRate = 40f;
    public float dodgeSpeedBleedCap = 3f;
    public float timeSinceLastDodgeStart = 0f;
    public bool currentlyInDodgeMovement = false;
    public float walkSpeed = 4f;
    public float airWalkSpeed = 3f;
    public float walkAccel = 15f;
    public float airWalkAccel = 7.5f;
    public bool instantWalk = false;
    public bool instantAirWalk = false;
    public bool instantWalkTurnaround = true;
    public bool instantAirWalkTurnaround = false;
    public bool grounded = false;
    public float health = Health.totalHealth;
    public Text healthText;
    public HealthBar healthBar;
    private IntangibilityController _intangibilityController;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;


    private void Start()
    {
        _intangibilityController = GetComponent<IntangibilityController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        healthText.text = "HP:\t\t\t\t" + Health.totalHealth;
        healthBar.SetSize(Health.totalHealth);
    }
    private void Update()
    {
        CheckGround();
        if(grounded)
        {
            dodgesInAirPerformed = 0;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && dodgeCooldownRemaining <= 0f)
        {
            if(grounded || dodgesInAirPerformed < dodgesInAirLimit)
            {
                _intangibilityController.BecomeTemporarilyIntangible(intangibilityWindow);
                dodgeCooldownRemaining = dodgeCooldownLimit;
                timeSinceLastDodgeStart = 0f;
                if(!grounded)
                {
                    dodgesInAirPerformed += 1;
                }
                DodgeStartMovement();
            }
        }
        RunWalkMovement();
        RunDodgeSpeedBleed();
        dodgeCooldownRemaining -= Time.deltaTime;
        timeSinceLastDodgeStart += Time.deltaTime;
        if(debugShowDodgeFrames)
        {
            VisualizeIntangibility();
        }
    }
    private void CheckGround()
    {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + Vector3.down * 1f,
            new Vector2(0.99f, 0.01f), 0f);
        foreach(Collider2D collider in colliders)
        {
            if(collider.transform.IsChildOf(transform) || transform.IsChildOf(collider.transform))
            {
                continue;
            }
            else
            {
                grounded = true;
            }
        }
    }
    private void RunWalkMovement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocityX = _rigidbody2D.velocity.x;
        if(grounded)
        {
            if(!Mathf.Approximately(inputX, 0f) && velocityX * Mathf.Sign(inputX) < inputX * walkSpeed * Mathf.Sign(inputX))
            {
                velocityX += inputX * walkAccel * Time.deltaTime;
                if(velocityX * Mathf.Sign(inputX) > inputX * walkSpeed * Mathf.Sign(inputX))
                {
                    velocityX = inputX * walkSpeed;
                }
            }
            if(instantWalkTurnaround)
            {
                if(!Mathf.Approximately(inputX, 0f) && Mathf.Approximately(Mathf.Sign(inputX),Mathf.Sign(velocityX) * -1f))
                {
                    velocityX = 0f;
                }
            }
            if(instantWalk)
            {
                velocityX = inputX * walkSpeed;
            }
        }
        else
        {
            if(!Mathf.Approximately(inputX, 0f) && velocityX * Mathf.Sign(inputX) < inputX * airWalkSpeed * Mathf.Sign(inputX))
            {
                velocityX += inputX * airWalkAccel * Time.deltaTime;
                if(velocityX * Mathf.Sign(inputX) > inputX * airWalkSpeed * Mathf.Sign(inputX))
                {
                    velocityX = inputX * airWalkSpeed;
                }
            }
            if(instantAirWalkTurnaround)
            {
                if(!Mathf.Approximately(inputX, 0f) && Mathf.Approximately(Mathf.Sign(inputX),Mathf.Sign(velocityX) * -1f))
                {
                    velocityX = 0f;
                }
            }
            if(instantAirWalk)
            {
                velocityX = inputX * airWalkSpeed;
            }
        }
        _rigidbody2D.velocity = new Vector2(velocityX, _rigidbody2D.velocity.y);
    }
    private void RunDodgeSpeedBleed()
    {
        _rigidbody2D.gravityScale = 1f;
        if(currentlyInDodgeMovement)
        {
            if(timeSinceLastDodgeStart > dodgeSpeedBleedDelay + dodgeSpeedBleedDuration)
            {
                currentlyInDodgeMovement = false;
            }
            if(currentlyInDodgeMovement && timeSinceLastDodgeStart < dodgeSpeedBleedDelay)
            {
                _rigidbody2D.gravityScale = 0f;
            }
            if(currentlyInDodgeMovement && timeSinceLastDodgeStart > dodgeSpeedBleedDelay)
            {
                float speed = _rigidbody2D.velocity.magnitude;
                if(speed > dodgeSpeedBleedCap)
                {
                    Vector2 normalizedVelocity = _rigidbody2D.velocity.normalized;
                    float newSpeed = Mathf.Max(dodgeSpeedBleedCap, speed - dodgeSpeedBleedRate * Time.deltaTime);
                    _rigidbody2D.velocity = normalizedVelocity * newSpeed;
                }
            }
        }
    }
    private void DodgeStartMovement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 inputVector = new Vector2(inputX, inputY);
        Vector2 inputVectorNormalized = inputVector.normalized;
        float inputMagnitude = inputVector.magnitude;
        if(inputMagnitude > 0.1f)
        {
            _rigidbody2D.velocity = inputVectorNormalized * dodgeInitialSpeed;
            currentlyInDodgeMovement = true;
        }
    }
    private void VisualizeIntangibility()
    {
        if(_intangibilityController.intangible)
        {
            _spriteRenderer.color = Color.blue;
        }
        else
        {
            _spriteRenderer.color = Color.green;
        }
    }
    private void PlayerTakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        Debug.Log(Health.totalHealth);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentlyInDodgeMovement == false)
        {
            if (collision.tag == "Spikes")
            {
                PlayerTakeDamage(50f);
                if ((Health.totalHealth -= 50f) > 0f)
                {
                    PlayerTakeDamage(50f);
                    healthBar.SetSize(Health.totalHealth);
                    healthText.text = "HP:\t\t\t\t" + Health.totalHealth;
                }
                else                
                {
                    Health.totalHealth = 0f;
                    healthText.text = "BIG DEAD";
                    healthBar.SetSize(Health.totalHealth);
                    // PlayerDie()
                }
            }
            else if (collision.tag == "Enemy")
            {
                //add enemy dmg
            }
        }  // ends here because Falling Off Map kills regardless of dodge          

        if (collision.tag == "FallDetector")
            {
                //PlayerDie(); // Death transition->respawn?
            }
    }
        
        
             
        
}

