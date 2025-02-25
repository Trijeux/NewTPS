using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TargetIsDead : MonoBehaviour
{
    [SerializeField] private bool isDead = false;
    [SerializeField] private TargetsManager targetsManager;

    public bool IsDead => isDead;
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Shoot"))
        {
            targetsManager.TargetIsDead();
            isDead = true;
        }
    }
}
