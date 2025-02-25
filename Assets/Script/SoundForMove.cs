using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Serialization;


public class SoundForMove : MonoBehaviour
{
    [SerializeField] private  ThirdPersonController _thirdPersonController;
    [SerializeField] private AudioSource _walkAudioSource;
    [SerializeField] private AudioSource _sprintAudioSource;
    [SerializeField] private bool _inWalk;
    [SerializeField] private bool _inSprint;

    // Update is called once per frame
    void Update()
    {
        if (_thirdPersonController._speedForSong >= 0.1f && _thirdPersonController._speedForSong <= 2 && !_inWalk)
        {
            _walkAudioSource.Play();
            _sprintAudioSource.Stop();
            _inWalk = true;
            _inSprint = false;
        }
        else if (_thirdPersonController._speedForSong >= 2.1f && !(_thirdPersonController._speedForSong <= 2) && !_inSprint)
        {
            _sprintAudioSource.Play();
            _walkAudioSource.Stop();
            _inSprint = true;
            _inWalk = false;
        }
        else if (_thirdPersonController._speedForSong <= 0f)
        {
            _walkAudioSource.Stop();
            _sprintAudioSource.Stop();
            _inWalk = false;
            _inSprint = false;
        }
        
    }
}
