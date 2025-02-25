using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
//[ExecuteInEditMode]
public class ShootingSysteme : MonoBehaviour
{
    [SerializeField] private GameObject _shootingTarget;
    [SerializeField] private GameObject _shootingTargetNoAim;
    [SerializeField] private GameObject _shootingTargetAim;
    [SerializeField] private GameObject _shootingOrigin;
    [SerializeField] private float _maxShootDistance = 300;
    [SerializeField] private GameObject _impact;
    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject UiAim;
    [SerializeField] private GameObject UiShoot;
    [SerializeField] private GameObject UiRun;
    [SerializeField] private GameObject UiControl;
    [SerializeField] private Text _maxAmmoText;
    [SerializeField] private Text _ammoText;
    [SerializeField] private Transform _CursorTransf;

    [FormerlySerializedAs("CameraV")] [SerializeField] private CinemachineVirtualCamera _cameraV;
    
    public bool _wasShot;
    public int _ammo;
    public int _ammoMax = 12;

    private bool flagUi = false;
    

    private StarterAssetsInputs _input;
    private Camera _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _mainCamera = Camera.main;
        _ammo = _ammoMax;
    }

    // Update is called once per frame
  
    void Update()
    {
        Vector3 shootPoint = _mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, _maxShootDistance));

        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);
           
        Physics.Raycast(ray, out RaycastHit hitInfo2, _maxShootDistance);
        _CursorTransf.SetPositionAndRotation(hitInfo2.point, _CursorTransf.rotation);
        
        if (_input.isAiming)
        {
            cross.SetActive(true);
            UiAim.SetActive(false);
            UiShoot.SetActive(true);
            UiRun.SetActive(false);
            _shootingTarget.transform.position = _shootingTargetAim.transform.position;

            if (!_wasShot && _input.isShot)
            {
                _wasShot = true;

                if (_input.isShot && _input.isAiming && _ammo > 0)
                {
                    _shootingOrigin.SetActive(true);
                    Vector3 forw = this.transform.forward;

                    Debug.DrawRay(ray.origin, _cameraV.transform.forward * _maxShootDistance, Color.red, 0.5f);
                    if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxShootDistance))
                    {
                        Debug.Log(hitInfo.collider.gameObject.name);
                        
                        if (hitInfo.collider.gameObject.tag != "Shoot")
                        {
                            Instantiate(_impact, hitInfo.point, Quaternion.identity);
                        }
                        
                    }

                    _ammo -= 1;
                }
                else
                {
                    _shootingOrigin.SetActive(false);
                }
            }
            else if (_wasShot && !_input.isShot)
            {
                _wasShot = false;
                _shootingOrigin.SetActive(false);
            }
        }
        else
        {
            UiAim.SetActive(true);
            UiRun.SetActive(true);
            UiShoot.SetActive(false);
            cross.SetActive(false);
            _shootingTarget.transform.position = _shootingTargetNoAim.transform.position;
        }

        if (_input.isReaload && _ammo <= 11)
        {
            _ammo = _ammoMax;
        }

        if (_input.isUI && !flagUi)
        {
            UiControl.SetActive(!UiControl.activeSelf);
            flagUi = true;
        }
        else if(!_input.isUI && flagUi)
        {
            flagUi = false;
        }
        
        _ammoText.text = _ammo.ToString();
        _maxAmmoText.text = _ammoMax.ToString();
    }
}