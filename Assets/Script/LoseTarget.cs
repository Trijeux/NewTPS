using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseTarget : MonoBehaviour
{
    public bool TargetLoseIsDead;
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Shoot"))
        {
            TargetLoseIsDead = true;
            gameObject.SetActive(false);
        }
    }
}
