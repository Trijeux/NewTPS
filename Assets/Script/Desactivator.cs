using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivator : MonoBehaviour
{
    [SerializeField] private EndGame _shootAllTarget;

    // Update is called once per frame
    void Update()
    {
        if (_shootAllTarget._end)
        {
            gameObject.SetActive(false);
        }
    }
}
