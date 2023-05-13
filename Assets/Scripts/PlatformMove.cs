using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformMove : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;
    private Vector3 startPos;
    private float movementRange;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        movementRange = distance / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = startPos + Vector3.up * Mathf.PingPong(Time.time * speed, movementRange * 2f) - Vector3.up * movementRange;

        transform.position = targetPosition;
    }
}
