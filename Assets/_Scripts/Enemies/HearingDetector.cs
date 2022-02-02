using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingDetector : MonoBehaviour
{
    private PlayerMovement _target;

    [SerializeField]
    private float _range = 3.0f;

    [SerializeField]
    private float _soundThreshold = 4.0f;


    public static Action OnPlayerDetected;
    public static Action OnPlayerHidden;
    private bool _playerInView;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void Awake()
    {
        _target = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange() && IsMakingNoise())
        {
            if (!_playerInView)
            {
                OnPlayerDetected?.Invoke();
                _playerInView = true;
            }
        }
        else
        {
            if (_playerInView)
            {
                OnPlayerHidden?.Invoke();
                _playerInView = false;
            }
        }
    }

    private bool IsInRange()
    {
        float distance = Vector2.Distance(_target.transform.position, transform.position);
        return distance < _range;
    }

    private bool IsMakingNoise()
    {
        return _soundThreshold < _target.Noise;
    }
}
