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
        if (state == Status.None || (GameManager.instance.playerStatus != PlayerStatus.Search && GameManager.instance.playerStatus != PlayerStatus.Select))
        {
            outline.enabled = false;
        }
        else if (state == Status.Outline)
        {
            outline.OutlineColor = Color.green;
            outline.enabled = true;
        }
        else if (state == Status.Select && GameManager.instance.playerStatus == PlayerStatus.Select)
        {
            outline.OutlineColor = Color.red;
        }
    }
    public void SetStatusNone()
    {
        state = Status.None;
    }
    public void SetStatusOutline()
    {
        state = Status.Outline;
    }
    public void SetStatusSelect()
    {
        state = Status.Select;
    }

}
