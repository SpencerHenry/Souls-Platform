using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    private RectTransform bar;

    private void Start()
    {
        bar = GetComponent<RectTransform>();
        SetSize(Health.totalHealth); // To Retain Health when switching between scenes
        
    }

    private void Update()
    {
        SetSize(Health.totalHealth);   
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size/Health.maximumHealth, 1f);
    }
}
