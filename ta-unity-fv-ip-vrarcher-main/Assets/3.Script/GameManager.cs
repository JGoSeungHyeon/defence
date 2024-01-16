using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStatus
{
    Idle,
    Battle,
    Search,
    Select,
    Teleport,
    UI

}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private GameObject RightSelect;
    [SerializeField] private GameObject RightTeleport;
    [SerializeField] private GameObject RightUI;
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject towerhp;
    public float MainHP;
    public int MyMoney = 0;
    public int MonsterCount = 0;
    public GameObject SeletedObject;
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
    private void Start()
    {
        MainHP = towerhp.GetComponent<TowerHP>().CastleHp;
    }
    private void Update()
    {
        if(playerStatus == PlayerStatus.Search && !RightSelect.activeSelf)
        {
            RightTeleport.SetActive(false);
            RightSelect.SetActive(true);
            RightUI.SetActive(false);
        }
        if(playerStatus == PlayerStatus.Teleport && !RightTeleport.activeSelf)
        {
            RightTeleport.SetActive(true);
            RightSelect.SetActive(false);
            RightUI.SetActive(false);
        }
        if(playerStatus == PlayerStatus.Idle || playerStatus == PlayerStatus.Battle)
        {
            RightTeleport.SetActive(false);
            RightSelect.SetActive(false);
            RightUI.SetActive(false);
        }
        if(playerStatus == PlayerStatus.UI || playerStatus == PlayerStatus.Select)
        {
            RightTeleport.SetActive(false);
            RightSelect.SetActive(false);
            RightUI.SetActive(true);
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
