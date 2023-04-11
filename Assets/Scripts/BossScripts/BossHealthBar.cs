using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private RectTransform bossBar;
    // Start is called before the first frame update
    void Start()
    {
        bossBar = GetComponent<RectTransform>();
        SetSize(BossHealth.totBossHealth);
    }

    // Update is called once per frame
    void Update()
    {
        SetSize(BossHealth.totBossHealth);
    }

    void SetSize(float size)
    {
        bossBar.localScale = new Vector3(size/BossHealth.maximumHealth, 1f);
    }
}
