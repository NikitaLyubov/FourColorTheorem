using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextButton : MonoBehaviour
{
    [SerializeField]
    private List<Figure> _figures;

    [SerializeField]
    private int _currentFigureIndex = 0;

    [SerializeField]
    private UnityEvent<Figure> _newFigureSelected;

    public void NextFigure()
    {
        SetCurrentFigureActive(false);

        _currentFigureIndex++;
        if (_currentFigureIndex >= _figures.Count)
            _currentFigureIndex = 0;

        SetCurrentFigureActive(true);

        _newFigureSelected?.Invoke(_figures[_currentFigureIndex]);
    }

    private void SetCurrentFigureActive(bool active)
    {
        _figures[_currentFigureIndex].gameObject.SetActive(active);
    }
}
