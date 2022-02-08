using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour, IDetect
{
    public Transform Target => _target;
    private Transform _target;

    public float Range => _range;
    [SerializeField]
    protected float _range = 1.5f;

    public Action OnPlayerDetected { get => OnPlayerDetectedintern; set => OnPlayerDetectedintern = value; }
    public Action OnPlayerHidden { get => OnPlayerHiddenintern; set => OnPlayerHiddenintern = value; }

    public Action OnPlayerDetectedintern;
    public Action OnPlayerHiddenintern;

    private void Awake()
    {
        _target = GameObject.FindObjectOfType<PlayerIdentifier>().transform;
    }

    void Update()
    {

    }

    public bool IsInRange()
    {
        float distance = Vector2.Distance(_target.position, transform.position);
        return distance < _range;
    }
}
