using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISee: IDetect
{ 
    float VisionAngle { get; }
    LayerMask WhatIsNotTransparent { get; }

    float GetAngleToPlayer();
    bool IsInAngle();
    bool IsBlockedView();
}
