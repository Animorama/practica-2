using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDetector : Detector, ISee
{
    public float VisionAngle => _visionAngle;
    [SerializeField]
    private float _visionAngle = 45f;

    public LayerMask WhatIsNotTransparent => _whatIsNotTransparent;
    [SerializeField]
    private LayerMask _whatIsNotTransparent;

    private bool _playerInView;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);

        Gizmos.color = Color.red;
        var _direction = Quaternion.AngleAxis(_visionAngle / 2, transform.forward) * transform.right;
        Gizmos.DrawRay(transform.position, _direction * Range);
        var _direction2 = Quaternion.AngleAxis(-_visionAngle / 2, transform.forward) * transform.right;
        Gizmos.DrawRay(transform.position, _direction2 * Range);

        Gizmos.color = Color.white;
    }

    

    // Update is called once per frame
    // TODO: pass this to parent
    void Update()
    {
        if (IsInRange() && IsInAngle() && !IsBlockedView())
        {
            if (!_playerInView)
            {
                PlayerDetected();
                _playerInView = true;
            }
        }
        else
        {
            if (_playerInView)
            {
                PlayerHidden();
                _playerInView = false;
            }
        }
    }

    public bool IsInAngle()
    {
        float angle = GetAngleToPlayer();
        return _visionAngle >= 2 * angle;
    }

    public float GetAngleToPlayer()
    {
        Vector2 v1 = transform.right;
        Vector2 v2 = Target.position - transform.position;
        return Vector2.Angle(v1, v2);
    }

    public bool IsBlockedView()
    {
        Vector2 _playerDirection = Target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _playerDirection, Range, WhatIsNotTransparent);

        return hit.transform != Target.transform;
    }
}