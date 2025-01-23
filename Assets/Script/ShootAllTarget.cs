using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootAllTarget : MonoBehaviour
{
    [SerializeField] private CompTargetDead _compTargetDead;
    public bool _end;
    
    // Update is called once per frame
    void Update()
    {
        if (_compTargetDead._targetLife <= 0)
        {
            _end = true;
        } 
    }
}
