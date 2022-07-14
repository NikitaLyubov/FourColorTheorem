using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private GameObject _figure;
    private int _segments;

    [SerializeField]
    private GameObject _nextButton;

    private RectTransform _transform;

    private int _errors = 0;
    private int _painted = 0;

    private void Start()
    {
        _segments = _figure.transform.childCount;
        _transform = GetComponent<RectTransform>();

        UpdateProgress(0, 0);
    }

    public void UpdateProgress(int painted, int errors)
    {
        _errors = _errors + errors < 0 ? 0 : _errors + errors;
        _painted = _painted + painted < 0 ? 0 : _painted + painted;

        int res = _painted - _errors < 0 ? 0 : _painted - _errors;

        _transform.localScale = new Vector2((float)res / _segments * 100, 100);

        _nextButton.SetActive(_painted == _segments && _errors == 0);
    }

    public void SetNewFigure(GameObject figure)
    {
        _errors = 0;
        _painted = 0;
        _segments = figure.transform.childCount;
    }
}
