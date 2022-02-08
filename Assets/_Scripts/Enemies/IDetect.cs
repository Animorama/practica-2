using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDetect
{
    Transform Target { get; }
    float Range { get; }

    Action OnPlayerDetected { get; set; }
    Action OnPlayerHidden { get; set; }

    bool IsInRange();
}
