using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMakeNoise
{
    float Noise { get; }

    abstract void EmitNoise();

}
