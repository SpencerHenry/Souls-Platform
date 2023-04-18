using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Transform castPosition;
    public GameObject projectile;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            // Spawn Projectile
            Instantiate(projectile, castPosition.position, castPosition.rotation);
        }
        
    }
}
