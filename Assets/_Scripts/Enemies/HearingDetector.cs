using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingDetector : Detector, IHear
{
    public float SoundThreshold => _soundThreshold;
    [SerializeField]
    private float _soundThreshold = 45f;

    private bool _playerInView;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange() && IsMakingNoise())
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

    public bool IsMakingNoise()
    {
        return _soundThreshold < Target.GetComponent<SoundTransmitter>().Noise;
    }
}
