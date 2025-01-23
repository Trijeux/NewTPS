using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIsDead : MonoBehaviour
{
    [SerializeField] private CompTargetDead _compTargetDead;
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Shoot"))
        {
            _compTargetDead.TargetIsDead();
            Destroy(gameObject);
        }
    }
}
