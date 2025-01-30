using StarterAssets;
using UnityEngine;
using UnityEngine.Serialization;

public class TutoUI : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs inputs;
    [SerializeField] private GameObject uimoveTuto;
    [SerializeField] private GameObject uiLookTuto;
    [SerializeField] private GameObject uiRunTuto;
    [SerializeField] private GameObject uiAimTuto;
    [SerializeField] private GameObject uiShootTuto;
    [SerializeField] private GameObject uiReloadTuto;
    [SerializeField] private GameObject uiShowHideUiTuto;
    private bool _learnMove = false;
    private bool _learnLook = false;
    private bool _learnRun = false;
    private bool _learnAim = false;
    private bool _learnShoot = false;
    private bool _learnReload = false;
    private bool _learnShowHideUI = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((inputs.move.x > 0.5 || inputs.move.y > 0.5) && !_learnMove)
        {
            uimoveTuto.SetActive(false);
            uiLookTuto.SetActive(true);
            _learnMove = true;
        }
        if ((inputs.look.x > 0.5 || inputs.look.y > 0.5) && _learnMove && !_learnLook)
        {
            uiLookTuto.SetActive(false);
            uiRunTuto.SetActive(true);
            _learnLook = true;
        }
        if (inputs.sprint && _learnLook && !_learnRun)
        {
            uiRunTuto.SetActive(false);
            uiAimTuto.SetActive(true);
            _learnRun = true;
        }
        if (inputs.isAiming && _learnRun && !_learnAim)
        {
            uiAimTuto.SetActive(false);
            uiShootTuto.SetActive(true);
            _learnAim = true;
        }
        if (inputs.isShot && _learnAim && !_learnShoot)
        {
            uiShootTuto.SetActive(false);
            uiReloadTuto.SetActive(true);
            _learnShoot = true;
        }
        if (inputs.isReaload && _learnShoot && !_learnReload)
        {
            uiReloadTuto.SetActive(false);
            uiShowHideUiTuto.SetActive(true);
            _learnReload = true;
        }
        if (inputs.isUI && _learnReload && !_learnShowHideUI)
        {
            uiShowHideUiTuto.SetActive(false);
            _learnShowHideUI = true;
        }
    }
}
