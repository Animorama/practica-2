using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTransmitter : MonoBehaviour, IMakeNoise
{

    public float Noise => _noise;
    private float _noise;

    public void EmitNoise(Rigidbody2D _rigidBody)
    {
        _noise = _rigidBody.velocity.magnitude;
    }
}
