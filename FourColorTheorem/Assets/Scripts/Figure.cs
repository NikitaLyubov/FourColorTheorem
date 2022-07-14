using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    private void OnDisable()
    {
        Clear();
    }

    public void Clear()
    {
        for (int i = transform.childCount - 1; i >= 0; --i)
        {
            transform.GetChild(i).GetComponent<Segment>().Clear();
        }
    }
}
