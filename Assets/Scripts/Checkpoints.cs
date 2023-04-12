using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
   public static Vector3 currCheckPoint;
   private void Start()
   {
        currCheckPoint = transform.position;
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
        if(col.tag == "CheckPoint")
        {
            currCheckPoint = transform.position;
        }
   }
}
