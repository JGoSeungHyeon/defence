using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStatus
{
    Idle,
    Battle,
    Search,
    Select,
    Teleport
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private GameObject RightSelect;
    [SerializeField] private GameObject RightTeleport;
    [SerializeField] private GameObject LeftHand;
    public PlayerStatus playerStatus = PlayerStatus.Search;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetBattle(bool Set)
    {

    }
    public void SetSearch(bool Set)
    {
        RightSelect.SetActive(Set);
    }
    public void SetCreate(bool Set)
    {

    }
}
