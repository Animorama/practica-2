﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool IsMoving => _isMoving;

    [SerializeField]
    private float Speed = 5;

    private bool _isMoving;

    //Components
    PlayerInput _input;
    Rigidbody2D _rigidbody;
    SoundTransmitter _soundTransmitter;
   
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _soundTransmitter = GetComponent<SoundTransmitter>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
   
    }

    private void Move()
    {
        Vector2 direction = new Vector2(_input.MovementHorizontal, _input.MovementVertical) 
            * (_input.Sneak ? Speed/2 : Speed);
        _rigidbody.velocity = direction;
       // transform.Translate(direction);
        _isMoving = direction.magnitude > 0.01f;

        if (_isMoving)
        {
            LookAt((Vector2)transform.position + direction);
            _soundTransmitter.EmitNoise(_rigidbody);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
           
    }

    void LookAt(Vector2 targetPosition)
    {
        float angle = 0;

        Vector3 relative = transform.InverseTransformPoint(targetPosition);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);
    }
}
