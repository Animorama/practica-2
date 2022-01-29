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

    private Vector3 forward = new Vector3(1, 0, 0);
    private Rigidbody2D _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

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
        transform.position += forward * Time.deltaTime * Speed;
    }

    private bool WallDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(DetectionPoint.position, forward, Distance, WhatIsWall);

        return hit.collider != null;

    }

    private void Flip()
    {
        int angle = Random.Range(90, 271); // 271 is exclusive
        forward = Rotate(forward, angle);
        float angle2 = Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg - 90f;
        _rigidBody.rotation = angle2;
        //transform.Rotate(new Vector3(0, 0, angle));
        //var rotation = Quaternion.LookRotation(Vector3.forward, forward);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 20 * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(0, 0, angle);

        Debug.Log(angle);
    }

    public static Vector2 Rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
