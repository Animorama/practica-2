using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingDetector : MonoBehaviour
{
    private Transform _target;

    [SerializeField]
    private float _range = 3.0f;

    [SerializeField]
    private float _soundThreshold = 4.0f;


    public static Action<GameObject> OnPlayerDetected;
    public static Action<GameObject> OnPlayerHidden;
    //public static Action<int> OnPlayerDetected;
    private bool _playerInView;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
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
        if (IsInRange() && IsMakingNoise())
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

    private bool IsInRange()
    {
        float distance = Vector2.Distance(_target.transform.position, transform.position);
        return distance < _range;
    }

    private bool IsMakingNoise()
    {
        return _soundThreshold < _target.GetComponent<SoundTransmitter>().Noise;
    }
}
