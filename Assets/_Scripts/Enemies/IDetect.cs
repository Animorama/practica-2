using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDetect
{
    Transform Target { get; }
    float Range { get; }

    Action<GameObject> OnPlayerDetected { get; }
    Action<GameObject> OnPlayerHidden { get; }

    bool IsInRange();
}
