using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TargetsManager : MonoBehaviour
{
    [SerializeField] private List<TargetIsDead> targets;
    [SerializeField] private TextMeshProUGUI _countOfTargetLifeText;
    [SerializeField] private AudioSource hitAudioSource;

    public List<TargetIsDead> Targets => targets;

    public void TargetIsDead()
    {
        hitAudioSource.Play();
    }

    private void Start()
    {
        targets.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);

            var script = child.GetComponent<TargetIsDead>();
            if (script != null)
            {
                targets.Add(script);
            }
        }
    }
    private void Update()
    {
        _countOfTargetLifeText.text = targets.Count.ToString();
        foreach (var target in targets.ToList().Where(target => target.IsDead))
        {
            Destroy(target.gameObject);
            targets.Remove(target);
        }
    }
    
}
