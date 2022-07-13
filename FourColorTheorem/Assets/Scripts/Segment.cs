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
        _neighbourSegments = new List<Segment>();
        _image = GetComponent<Image>();
        _startColor = _image.color;

        _errors = 0;
    }

    public Color GetCurrentColor()
    {
        return _image.color;
    }

    private void OnMouseDown()
    {
        _color = ChoseColor.Color;

        if (_canPaint)
        {
            if (_image.color == _color)
            {
                Clear();
            }
            else
            {
                int painted = _image.color == _startColor ? 1 : 0;

                _image.color = _color;

                _errors = 0;

                for (int i = 0; i < _neighbourSegments.Count; ++i)
                {
                    if (_neighbourSegments[i].GetCurrentColor() == _image.color)
                        _errors++;
                }

                _event.Invoke(painted, _errors);
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
        _image.color = _startColor; 
        
        _event.Invoke(-1, -_errors);
        _errors = 0;
    }
}
