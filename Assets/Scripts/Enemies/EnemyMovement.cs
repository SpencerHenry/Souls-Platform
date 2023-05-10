using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   private Rigidbody2D myRigidbody;

   private Vector3 startPosition;
   public Vector3 endPosition;

   private Vector3 targetPosition;

   public float movementSpeed;

   void Awake()
   {
        myRigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        targetPosition = endPosition;
   }

   void FixedUpdate()
   {

        Vector3 currentPosition = transform.position;

        if(currentPosition == endPosition)
        {
            targetPosition = startPosition;
            Debug.Log("Reached end, turning around");
        }
        else if(currentPosition == startPosition)
        {
            targetPosition = endPosition;
            Debug.Log("At start, moving towards target location");
        }

        Vector3 targetDirection = (targetPosition - currentPosition).normalized;
        myRigidbody.MovePosition(currentPosition + targetDirection * movementSpeed * Time.deltaTime);
   }
}
