using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlarm : MonoBehaviour
{
    SpriteRenderer _alarmRenderer;

    private void OnEnable()
    {
        GetComponentInParent<VisionDetector>().OnPlayerDetected += PlayerDetected;
        GetComponentInParent<VisionDetector>().OnPlayerHidden += PlayerLeft;
        GetComponentInParent<HearingDetector>().OnPlayerDetected += PlayerDetected;
        GetComponentInParent<HearingDetector>().OnPlayerHidden += PlayerLeft;
    }
    private void OnDisable()
    {
        GetComponentInParent<VisionDetector>().OnPlayerDetected -= PlayerDetected;
        GetComponentInParent<VisionDetector>().OnPlayerHidden -= PlayerLeft;
        GetComponentInParent<HearingDetector>().OnPlayerDetected -= PlayerDetected;
        GetComponentInParent<HearingDetector>().OnPlayerHidden -= PlayerLeft;
    }

    public void PlayerDetected()
    {
        ChangeColor(Color.red);
    }

    public void PlayerLeft()
    {
        ChangeColor(new Color(0,0,0,0));
    }

    private void ChangeColor(Color color)
    {
        if (_alarmRenderer == null)
        {
            _alarmRenderer = GetComponent<SpriteRenderer>();
        }

        _alarmRenderer.color = color;
    }
}
