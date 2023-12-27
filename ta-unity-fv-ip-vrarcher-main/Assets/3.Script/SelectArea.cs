using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    None,
    Outline,
    Select,
    Create
}



public class SelectArea : MonoBehaviour
{
    public Status state;
    [SerializeField] private Outline outline;
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    private void Update()
    {
        if (state == Status.None)
        {
            outline.enabled = false;
        }
        else if (state == Status.Outline)
        {
            outline.enabled = true;
        }
        else if (state == Status.Select)
        {
            outline.OutlineColor = Color.red;
        }
    }
}
