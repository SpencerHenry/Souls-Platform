using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerDodge))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerCombat))]
public class PlayerActionController : MonoBehaviour
{
    public bool facingRight = true;
    public bool paralyzed = false;
    private bool temporarilyParalyzed = false;
    private float temporarilyParalyzedSeconds = 0f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private PlayerDodge _playerDodge;
    private PlayerCombat _playerCombat;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerDodge = GetComponent<PlayerDodge>();
        _playerCombat = GetComponent<PlayerCombat>();
    }
    private void Update()
    {
        if(temporarilyParalyzed)
        {
            temporarilyParalyzedSeconds -= Time.deltaTime;
            if(temporarilyParalyzedSeconds <= 0f)
            {
                temporarilyParalyzed = false;
                paralyzed = false;
            }
        }
        if(paralyzed || PauseMenu.gameIsPaused)
        {
            return;
        }
        setAnimationSpeed();
        changeDirection();
        if(Input.GetMouseButtonDown(0) &&
           (_animator.GetCurrentAnimatorStateInfo(0).IsName("CharacterRunAnimation") ||
            _animator.GetCurrentAnimatorStateInfo(0).IsName("CharacterIdleAnimation")))
        {
            _playerCombat.Attack();
            _animator.SetTrigger("Attack");
        }
    }
    public void Knockback(Vector2 velocityChange, bool stun = false, float stunTime = 0f)
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.velocity += velocityChange;
        if(stun)
        {
            TemporarilyParalyze(stunTime);
        }
    }
    public void Paralyze()
    {
        paralyzed = true;
        temporarilyParalyzed = false;
    }
    public void Unparalyze()
    {
        paralyzed = false;
        temporarilyParalyzed = false;
    }
    public void TemporarilyParalyze(float seconds)
    {
        if(paralyzed)
        {
            if(temporarilyParalyzed && seconds > temporarilyParalyzedSeconds)
            {
                temporarilyParalyzedSeconds = seconds;
            }
            return;
        }
        paralyzed = true;
        temporarilyParalyzed = true;
        temporarilyParalyzedSeconds = seconds;
    }
    private void FlipFacing()
    {
        facingRight = !facingRight;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
    private void setAnimationSpeed()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        if(_playerDodge.grounded)
        {
            _animator.SetFloat("Speed", Mathf.Abs(inputX));
        }
        else
        {
            _animator.SetFloat("Speed", 0f);
        }
    }
    private void changeDirection()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        if((inputX > 0 && !facingRight) || (inputX < 0 && facingRight))
        {
            FlipFacing();
        }
    }
}
