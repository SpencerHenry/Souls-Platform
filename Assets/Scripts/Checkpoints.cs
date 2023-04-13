using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoints : MonoBehaviour
{
   public static Vector3 currCheckPoint;
   public static bool checkpointSet = false;
   public Text WINTEXT;
   private void Start()
   {
       if(checkpointSet)
       {
           transform.position = currCheckPoint;
       }
       else
       {
           checkpointSet = true;
           currCheckPoint = transform.position;
       }
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
        if(col.tag == "Win")
        {
            WINTEXT.gameObject.SetActive(true);
        }
        if(col.tag == "CheckPoint")
        {
            currCheckPoint = transform.position;
            checkpointSet = true;
        }
   }
}
