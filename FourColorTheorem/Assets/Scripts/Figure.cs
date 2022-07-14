using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    private void OnDisable()
    {
        for (int i = transform.childCount; i >= 0; --i)
        {
            transform.GetChild(i).GetComponent<Segment>().Clear();
        }
    }
}
