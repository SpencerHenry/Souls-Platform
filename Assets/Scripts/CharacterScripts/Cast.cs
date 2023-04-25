using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public Transform castPoint;
    public GameObject projectilePrefab;
 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(projectilePrefab,castPoint.position,transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.tag == "Bat")
        {
            Destroy(projectilePrefab);
        }
    }
}
