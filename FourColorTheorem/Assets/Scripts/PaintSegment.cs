using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaintSegment : MonoBehaviour
{
    private Color _color;
    private Image _image;
    private Color _startColor;
    private bool _canPaint;

    private void Start()
    {
        _image = GetComponent<Image>();
        _startColor = _image.color;
    }

    private void OnMouseDown()
    {
        _color = ChoseColor.Color;
        if (_canPaint)
        {
            _image.color = _image.color == _color ? _startColor : _color;
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
    }
}
