using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{
    [SerializeField]
    private Figure _figure;

    public void SetNewFigure(Figure figure)
    {
        _figure = figure;
    }

    public void ClearFigure()
    {
        _figure.Clear();
    }
}
