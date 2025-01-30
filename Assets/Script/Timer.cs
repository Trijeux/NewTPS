using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timer = 360;
    private bool _timeEnd = false;
    [SerializeField]private TextMeshProUGUI timerText;

    public bool TimeEnd => _timeEnd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        timerText.text = Mathf.FloorToInt(_timer / 60).ToString("00") + ":" + Mathf.FloorToInt(_timer % 60).ToString("00");
        if (_timer < 0)
        {
            _timeEnd = true;
        }
    }
}
