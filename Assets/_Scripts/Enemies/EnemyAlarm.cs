using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlarm : MonoBehaviour
{
    SpriteRenderer _alarmRenderer;

    private void OnEnable()
    {
        VisionDetector.OnPlayerDetected += PlayerDetected;
        VisionDetector.OnPlayerHidden += PlayerLeft;
        HearingDetector.OnPlayerDetected += PlayerDetected;
        HearingDetector.OnPlayerHidden += PlayerLeft;
    }
    private void OnDisable()
    {
        VisionDetector.OnPlayerDetected -= PlayerDetected;
        VisionDetector.OnPlayerHidden -= PlayerLeft;
        HearingDetector.OnPlayerDetected -= PlayerDetected;
        HearingDetector.OnPlayerHidden -= PlayerLeft;
    }

    public void PlayerDetected(GameObject _enemy)
    {
        ChangeColor(Color.red, _enemy);
    }

    public void PlayerLeft(GameObject _enemy)
    {
        ChangeColor(new Color(0,0,0,0), _enemy);
    }

    private void ChangeColor(Color color, GameObject _enemy)
    {
        //if (_alarmRenderer == null)
        //{
        //    _alarmRenderer = _enemy.GetComponentInChildren<SpriteRenderer>();
        //    _alarmRenderer = _enemy.transform.GetChild(0).GetComponent<SpriteRenderer>();
        //}

        _alarmRenderer = _enemy.transform.GetChild(0).GetComponent<SpriteRenderer>();

        _alarmRenderer.color = color;
    }

    //Dejo esto aquí para plantear si podemos pasar parametros para que solo se ponga rojo un enemy a la vez.

    //public void IncreaseScore(int value)
    //{
    //    Score += value;
    //    OnScoreChanged?.Invoke(Score);
    //}
}
