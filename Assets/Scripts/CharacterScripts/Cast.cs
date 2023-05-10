using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public Transform castPoint;
    public GameObject projectilePrefab;
    private PlayerActionController _playerActionCon; 

    void Start() 
    {
        _playerActionCon = GetComponent<PlayerActionController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(_playerActionCon == null)
            {
                Debug.Log(gameObject.name);
            }
            GameObject orb = Instantiate(projectilePrefab,castPoint.position,transform.rotation);
            if(!_playerActionCon.facingRight)
            {
               orb.transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, 1f);
            }
        }
    }
}
