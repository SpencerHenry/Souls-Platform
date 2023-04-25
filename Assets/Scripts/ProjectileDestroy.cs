using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    public GameObject projectile;

    void Update()
    {
        if(Input.GetMouseButton(2)) 
        {
            Destroy(gameObject);
        }
    }

}
