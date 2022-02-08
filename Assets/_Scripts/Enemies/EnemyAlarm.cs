using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlarm : MonoBehaviour
{
    SpriteRenderer _alarmRenderer;

    private void OnEnable()
    {
        GetComponentInParent<IDetect>().OnPlayerDetected += PlayerDetected;
        GetComponentInParent<IDetect>().OnPlayerHidden += PlayerLeft;
    }
    private void OnDisable()
    {
        GetComponentInParent<IDetect>().OnPlayerDetected -= PlayerDetected;
        GetComponentInParent<IDetect>().OnPlayerHidden -= PlayerLeft;
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
