using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDetector : MonoBehaviour
{
    private Transform _target;

    [SerializeField]
    private float _range = 1.5f;
    [SerializeField]
    private float _visionAngle = 45f;

    [SerializeField]
    private LayerMask WhatIsNotTransparent;

    public static Action OnPlayerDetected;
    public static Action OnPlayerHidden;
    private bool _playerInView;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _range);

        Gizmos.color = Color.red;
        var _direction = Quaternion.AngleAxis(_visionAngle / 2, transform.forward) * transform.right;
        Gizmos.DrawRay(transform.position, _direction * _range);
        var _direction2 = Quaternion.AngleAxis(-_visionAngle / 2, transform.forward) * transform.right;
        Gizmos.DrawRay(transform.position, _direction2 * _range);

        Gizmos.color = Color.white;
    }

    private void Awake()
    {
        _target = GameObject.FindObjectOfType<PlayerIdentifier>().transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange() && IsInAngle() && !IsBlockedView())
        {
            OnPlayerDetected?.Invoke();
        }
        else
        {
            OnPlayerHidden?.Invoke();
        }
    }

    private bool IsInRange()
    {
        float distance = Vector2.Distance(_target.position, transform.position);
        return distance < _range;
    }

    private bool IsInAngle()
    {
        float angle = GetAngleToPlayer();
        return _visionAngle >= 2 * angle;
    }

    private float GetAngleToPlayer()
    {
        Vector2 v1 = transform.right;
        Vector2 v2 = _target.position - transform.position;
        return Vector2.Angle(v1, v2);
    }

    private bool IsBlockedView()
    {
        Vector2 _playerDirection = _target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _playerDirection, _range, WhatIsNotTransparent);

        return hit.transform != _target.transform;
    }
}
