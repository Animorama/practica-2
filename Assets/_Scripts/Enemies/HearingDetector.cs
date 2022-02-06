using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingDetector : MonoBehaviour, IHear
{
    public Transform Target => _target;
    private Transform _target;

    public float Range => _range;
    [SerializeField]
    private float _range = 3.0f;

    public float SoundThreshold => _soundThreshold;
    [SerializeField]
    private float _soundThreshold = 45f;

    Action<GameObject> IDetect.OnPlayerDetected => OnPlayerDetected;
    Action<GameObject> IDetect.OnPlayerHidden => OnPlayerHidden;

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

    public bool IsInRange()
    {
        float distance = Vector2.Distance(_target.transform.position, transform.position);
        return distance < _range;
    }

    public bool IsMakingNoise()
    {
        return _soundThreshold < _target.GetComponent<SoundTransmitter>().Noise;
    }
}
