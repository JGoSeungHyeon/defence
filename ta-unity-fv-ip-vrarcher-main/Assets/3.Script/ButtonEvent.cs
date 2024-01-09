using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private GameObject HandMenu;
    public void ExitMenu()
    {
        HandMenu.SetActive(false);
        GameManager.instance.playerStatus = PlayerStatus.Idle;
    }
}
