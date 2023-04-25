using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public Transform castPoint;
    public GameObject projectilePrefab;
    public bool projectileActive = false;
 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            projectileActive = true;
            Instantiate(projectilePrefab,castPoint.position,transform.rotation);  
        }
    }
}
