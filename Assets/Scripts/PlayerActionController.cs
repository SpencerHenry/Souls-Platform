using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerDodge))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerActionController : MonoBehaviour
{
    public bool facingRight = true;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private PlayerDodge _playerDodge;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerDodge = GetComponent<PlayerDodge>();
    }
    private void Update()
    {
        setAnimationSpeed();
        directionCheck();  
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
        if(_playerDodge.grounded)
        {
            _animator.SetFloat("Speed", Mathf.Abs(inputX));
        }
        else
        {
            _animator.SetFloat("Speed", 0f);
        }
    }
    private void directionCheck()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        if((inputX > 0 && !facingRight) || (inputX < 0 && facingRight))
        {
            FlipFacing();
        }
    }
}
