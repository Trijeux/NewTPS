using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TargetsManager targetsManager;
    [SerializeField] private Timer _timer;
    [SerializeField] public bool _end;
    [SerializeField] private GameObject uiEndGame;
    [SerializeField] private GameObject uiWin;
    [SerializeField] private GameObject uiLose;

    // Update is called once per frame
    void Update()
    {
        if (targetsManager.Targets.Count <= 0)
        {
            uiEndGame.SetActive(true);
            uiWin.SetActive(true);
            _end = true;
        }
        if (_timer.TimeEnd)
        {
            uiEndGame.SetActive(true);
            uiLose.SetActive(true);
            _end = true;
        }
    }
}
