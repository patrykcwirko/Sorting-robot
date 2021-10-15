using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI text;

    private float _time = 0.000f;
    private bool _active = false;

    public void StartTimer()
    {
        _time = 0.000f;
        _active = true;
    }

    public void EndTimer()
    {
        _active = false;
    }

    private void Update()
    {
        if (!_active) return;
        _time += Time.deltaTime;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = "Time: " + _time.ToString();
    }

}
