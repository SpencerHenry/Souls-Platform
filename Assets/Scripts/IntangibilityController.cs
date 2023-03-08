using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IntangibilityController : MonoBehaviour
{
    public bool intangible = false;
    public bool temporarilyIntangible = false;
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
    }
    public void BecomeIntangible()
    {
        intangible = true;
    }
    public void BecomeNotIntangible()
    {
        intangible = false;
        temporarilyIntangible = false;
    }
    public void BecomeTemporarilyIntangible(float timeSeconds)
    {
        if(intangible)
        {
            if(temporarilyIntangible)
            {
                temporarilyIntangibleTime = Mathf.Max(temporarilyIntangibleTime, timeSeconds);
            }
            return;
        }
        BecomeIntangible();
        temporarilyIntangible = true;
        temporarilyIntangibleTime = timeSeconds;
    }
}
