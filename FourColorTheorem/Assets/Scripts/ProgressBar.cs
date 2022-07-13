using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private GameObject _figure;
    private int _segments;

    [SerializeField]
    private GameObject _nextButton;

    private Slider _slider;

    private int _errors = 0;
    private int _painted = 0;

    private void Start()
    {
        _segments = _figure.transform.childCount;
        _slider = GetComponent<Slider>();

        UpdateProgress(0, 0);
    }

    public void UpdateProgress(int painted, int errors)
    {
        _errors += errors;
        _painted += painted;

        _errors = _errors < 0 ? 0 : _errors;
        _painted = _painted < 0 ? 0 : _painted;

        int res = _painted - _errors < 0 ? 0 : _painted - _errors;

        _slider.value = (float)res / _segments;

        _nextButton.SetActive(_painted == _segments && _errors == 0);
    }
}
