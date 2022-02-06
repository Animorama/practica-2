using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDetector : MonoBehaviour, ISee
{
    public Transform Target => _target;
    private Transform _target;

    public float Range => _range;
    [SerializeField]
    private float _range = 1.5f;

    public float VisionAngle => _visionAngle;
    [SerializeField]
    private float _visionAngle = 45f;

    public LayerMask WhatIsNotTransparent => _whatIsNotTransparent;
    [SerializeField]
    private LayerMask _whatIsNotTransparent;

    Action<GameObject> IDetect.OnPlayerDetected => OnPlayerDetected;
    Action<GameObject> IDetect.OnPlayerHidden => OnPlayerHidden;

    public static Action<GameObject> OnPlayerDetected;
    public static Action<GameObject> OnPlayerHidden;
    //public static Action<int> OnPlayerDetected;

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
            if (!_playerInView)
            {
                OnPlayerDetected?.Invoke(this.gameObject);
                _playerInView = true;
            }
        }
        else
        {
            if (_playerInView)
            {
                OnPlayerHidden?.Invoke(this.gameObject);
                _playerInView = false;
            }
        }
    }

    public bool IsInRange()
    {
        float distance = Vector2.Distance(_target.position, transform.position);
        return distance < _range;
    }

    public bool IsInAngle()
    {
        float angle = GetAngleToPlayer();
        return _visionAngle >= 2 * angle;
    }

    public float GetAngleToPlayer()
    {
        Vector2 v1 = transform.right;
        Vector2 v2 = _target.position - transform.position;
        return Vector2.Angle(v1, v2);
    }

    public bool IsBlockedView()
    {
        Vector2 _playerDirection = _target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _playerDirection, _range, WhatIsNotTransparent);

        return hit.transform != _target.transform;
    }
}
