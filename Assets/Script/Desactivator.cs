using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivator : MonoBehaviour
{
    [SerializeField] private ShootAllTarget _shootAllTarget;
    [SerializeField] private LoseTarget _loseTarget;

    // Update is called once per frame
    void Update()
    {
        if (_shootAllTarget._end || _loseTarget.TargetLoseIsDead)
        {
            gameObject.SetActive(false);
        }
    }
}
