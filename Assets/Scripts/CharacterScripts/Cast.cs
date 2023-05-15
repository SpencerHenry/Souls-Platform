using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public Transform castPoint;
    public GameObject projectilePrefab;
    public bool projectileActive = false;
    public PlayerActionController _playerActionCon;
 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(_playerActionCon == null)
            {
                Debug.Log(gameObject.name);
            }

            Instantiate(projectilePrefab,castPoint.position,transform.rotation);

            
        }
    }

    
}
