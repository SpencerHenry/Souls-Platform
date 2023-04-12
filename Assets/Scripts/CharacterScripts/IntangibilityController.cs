using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IntangibilityController : MonoBehaviour
{
    public bool displayOnSprite = false;
    public SpriteRenderer spriteRend;
    public Color damageColor;
    public Color dodgeColor;
    public bool intangible = false;
    public bool temporarilyIntangible = false;
    public bool becauseOfDamage = false;
    public float temporarilyIntangibleTime = 0f;
    private void Update()
    {
        if(temporarilyIntangible)
        {
            temporarilyIntangibleTime -= Time.deltaTime;
            if(temporarilyIntangibleTime <= 0f)
            {
                BecomeNotIntangible();
            }
        }
        if(spriteRend != null)
        {
            if(temporarilyIntangible && displayOnSprite)
            {
                Color color;
                if(becauseOfDamage)
                {
                    color = damageColor;
                }
                else
                {
                    color = dodgeColor;
                }
                spriteRend.color = color;
            }
            else
            {
                spriteRend.color = Color.white;
            }
        }
    }
    public void BecomeIntangible()
    {
        intangible = true;
    }
    public void BecomeNotIntangible()
    {
        intangible = false;
        temporarilyIntangible = false;
        becauseOfDamage = false;
    }
    public void BecomeTemporarilyIntangible(float timeSeconds, bool fromDamage = false)
    {
        if(intangible)
        {
            if(temporarilyIntangible && timeSeconds > temporarilyIntangibleTime)
            {
                becauseOfDamage = fromDamage;
                temporarilyIntangibleTime = timeSeconds;
            }
            return;
        }
        BecomeIntangible();
        temporarilyIntangible = true;
        temporarilyIntangibleTime = timeSeconds;
        becauseOfDamage = fromDamage;
    }
}
