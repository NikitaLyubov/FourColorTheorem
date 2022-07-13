using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private GameObject _figure;
    private int _segments;
    
    [SerializeField]
    private GameObject _fullPB;

    [SerializeField]
    private GameObject _nextButton;

    private int _errors = 0;
    private int _painted = 0;

    private void Start()
    {
        _segments = _figure.transform.childCount;

        UpdateProgress(0, 0);
    }

    public void UpdateProgress(int painted, int errors)
    {
        _errors += errors;
        _painted += painted;

        _errors = _errors < 0 ? 0 : _errors;
        _painted = _painted < 0 ? 0 : _painted;

        var fullPBtransform = _fullPB.GetComponent<RectTransform>();

        int res = _painted - _errors < 0 ? 0 : _painted - _errors;

        fullPBtransform.localScale = new Vector3((float)res / _segments, 1, 1);

        _nextButton.SetActive(_painted == _segments && _errors == 0);
    }
}
