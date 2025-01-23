using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CompTargetDead : MonoBehaviour
{
    [SerializeField] private int _countOfTargetLife = 16;
    [SerializeField] private Text _countOfTargetLifeText;
    [SerializeField] private AudioSource _hitAudioSource;
    public int _targetLife;
    public void StringTargetLife()
    { 
        _countOfTargetLifeText.text = _countOfTargetLife.ToString();
    }

    public void TargetIsDead()
    {
        _hitAudioSource.Play();
        _countOfTargetLife--;
    }

    private void Start()
    {
        _targetLife = _countOfTargetLife;
    }
    private void Update()
    {
        _targetLife = _countOfTargetLife;
    }
    
}
