using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Text healthText;
    private RectTransform bar;

    private void Start()
    {
        bar = GetComponent<RectTransform>();
        SetSize(Health.totalHealth); // To Retain Health when switching between scenes
        healthText.text = "HP:\t\t\t\t" + Health.totalHealth;
    }

    private void Update()
    {
        SetSize(Health.totalHealth);
        if(Health.totalHealth > 0)
        {
            healthText.text = "HP:\t\t\t\t" + Health.totalHealth;
        }
        else
        {
            healthText.text = "\t\tDEAD";
        }
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size/Health.maximumHealth, 1f);
    }
}
