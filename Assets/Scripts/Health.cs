using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static float totalHealth = 100;
    private RectTransform healthBar;
    
    public void updateHealthBar(float size)
    {
        healthBar.localScale = new Vector3(size, 1f);
    }

      


}
