using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(IntangibilityController))]
public class PlayerDodge : MonoBehaviour
{
    public bool dodgeEnabled = true;
    public float dodgeCooldownLimit = 0.5f;
    public float dodgeCooldownRemaining = 0f;
    public bool debugShowDodgeFrames = false;
    public float intangibilityWindow = 0.25f;
    private IntangibilityController _intangibilityController;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _intangibilityController = GetComponent<IntangibilityController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && dodgeCooldownRemaining <= 0f)
        {
            _intangibilityController.BecomeTemporarilyIntangible(intangibilityWindow);
            dodgeCooldownRemaining = dodgeCooldownLimit;
        }
        dodgeCooldownRemaining -= Time.deltaTime;
        if(debugShowDodgeFrames)
        {
            VisualizeIntangibility();
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
}
