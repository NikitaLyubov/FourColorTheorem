using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoseColor : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private GameObject selectPrefab;

    public static Color Color = new Color(217, 217, 217);

    public static bool IsChosen { get; private set; } = false;
 

    public void OnPointerDown(PointerEventData eventData)
    {
        IsChosen = true;

        Color = GetComponent<Image>().color;
        selectPrefab.SetActive(true);
        selectPrefab.transform.SetParent(transform);
        selectPrefab.transform.localPosition = Vector3.zero;
    }
}
