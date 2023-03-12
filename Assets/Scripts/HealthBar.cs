using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    private RectTransform bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<RectTransform>();
        SetSize(Health.totalHealth); // To Retain Health when switching between scenes
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size/100, 1f);
    }
}
