using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTransmitter : MonoBehaviour, IMakeNoise
{

    public float Noise => _noise;
    private float _noise;

    //Function parameters
    private Rigidbody2D _rigidBody;

    public void EmitNoise(Rigidbody2D _rigidBody)
    {
        _noise = _rigidbody.velocity.magnitude;
    }
}
