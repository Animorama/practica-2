using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHear: IDetect
{
    float SoundThreshold { get; }

    bool IsMakingNoise();
}
