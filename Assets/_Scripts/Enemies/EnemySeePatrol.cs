using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeePatrol : MonoBehaviour
{
    [SerializeField]
    private float Speed = 3f;
    [SerializeField]
    private Transform DetectionPoint;
    [SerializeField]
    private float Distance;
    [SerializeField]
    private LayerMask WhatIsWall;

    // Update is called once per frame
    void Update()
    {
        if (WallDetected())
        {
            Flip();
        }

        Move();
    }

    private void Move()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private bool WallDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(DetectionPoint.position, transform.right, Distance, WhatIsWall);
        return hit.collider != null;
    }

    private void Flip()
    {
        int angle = Random.Range(90, 271); // 271 is exclusive
        transform.Rotate(0.0f, 0.0f, angle, Space.Self);
    }

}
