using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Segment : MonoBehaviour
{
    [SerializeField]
    private List<Segment> _neighbourSegments;

    [SerializeField]
    private UnityEvent<int, int> _event;

    private Color _color;
    private Image _image;
    private Color _startColor;
    private bool _canPaint;

    private int _errors;

    void Start()
    {
        _image = GetComponent<Image>();
        _startColor = _image.color;

        _errors = 0;
    }

    public Color Color()
    {
        return _image.color;
    }

    public void IncrementErrors()
    {
        _errors++;
    }

    private void OnMouseDown()
    {
        if (_canPaint && ChoseColor.IsChosen)
        {
            _color = ChoseColor.Color;

            if (_image.color == _color)
            {
                Clear();
            }
            else
            {
                int painted = _image.color == _startColor ? 1 : 0;

                _image.color = _color;

                int newErrors = 0;

                for (int i = 0; i < _neighbourSegments.Count; ++i)
                {
                    if (_neighbourSegments[i].Color() == _image.color)
                    {
                        newErrors++;
                        _neighbourSegments[i].IncrementErrors();
                    }
                }

                _event.Invoke(painted, newErrors - _errors);

                _errors = newErrors;
            }
        }
    }

    private void OnMouseEnter()
    {
        _canPaint = true;
    }

    private void OnMouseExit()
    {
        _canPaint = false;
    }

    public void Clear()
    {
        _event.Invoke(-1, -_errors);
        _errors = 0;

        _image.color = _startColor;
    }
}
