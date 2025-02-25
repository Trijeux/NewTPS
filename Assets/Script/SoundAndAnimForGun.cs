using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;

public class SoundAndAnimForShoot : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _inputs;
    [SerializeField] private AudioSource _ShootingSource;
    [SerializeField] private AudioSource _NoAmmoShootSource;
    [SerializeField] private AudioSource _RealoadSource;
    [SerializeField] private ParticleSystem _particle;

    [SerializeField] private ShootingSysteme _shootingSysteme;
    [SerializeField] private bool _wasShotForSong;
    [SerializeField] private bool _ammoForSong;

    // Update is called once per frame
    void Update()
    {
        if (_inputs.isShot && _inputs.isAiming && _shootingSysteme._ammo > 0 && !_wasShotForSong)
        {
            _ShootingSource.Play();
            _particle.Play();
            _wasShotForSong = _shootingSysteme._wasShot;
        }
        else if(_inputs.isShot && _inputs.isAiming && _shootingSysteme._ammo <= 0 && !_wasShotForSong)
        {
            _NoAmmoShootSource.Play();
            _wasShotForSong = _shootingSysteme._wasShot;
        }
        else
        {
            _wasShotForSong = _shootingSysteme._wasShot;
        }
        
        if (_inputs.isReaload && _ammoForSong)
        {
            _RealoadSource.Play();
            _ammoForSong = false;
        }
        else if (_shootingSysteme._ammo <= 11)
        {
            _ammoForSong = true;
        }
        else
        {
            _ammoForSong = false;
        }
    }
}
