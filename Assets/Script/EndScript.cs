using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    [SerializeField] private EndGame _shootAllTarget;
    [SerializeField] private LoseTarget _loseTarget;
    [SerializeField] private Text _endText;
    [SerializeField] private Text _felicitationAndPerduText;
    [SerializeField] private AudioSource  _winAudioSource;
    [SerializeField] private AudioSource  _perduAudioSource;
    [SerializeField] private bool _songOn;
    [SerializeField] private GameObject _rabbitIsDeadGameObject;

    // Update is called once per frame
    void Update()
    {
        if (_shootAllTarget._end && !_songOn)
        {
            _endText.text = "Vous avez réussi a tirer sur toute les cible !!!";
            _felicitationAndPerduText.text = "Félicitations";
            _songOn = true;
            if (_songOn)
            {
                _winAudioSource.Play();
            }
            
        }

        if (_loseTarget.TargetLoseIsDead && !_songOn)
        {
            _endText.text = "Vous avez tué le lapin, vous êtes un monstre";
            _felicitationAndPerduText.text = "Perdu";
            _rabbitIsDeadGameObject.SetActive(true);
            _songOn = true;
            if (_songOn)
            {
                _perduAudioSource.Play();
            }
        }
    }
}
