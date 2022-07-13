using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Misstakes : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    private int _errors;

    public void UpdateErrors(int painted, int errors)
    {
        _errors = _errors + errors < 0 ? 0 : _errors + errors;

        _text.text = $"Îøèáêè: {_errors}";
    }
}
