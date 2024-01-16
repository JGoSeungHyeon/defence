using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TowerObject
{
    public GameObject TowerPrefab;
    public int Money;
}

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private GameObject HandMenu;
    [SerializeField] private GameObject AskMenu;
    [SerializeField] private GameObject[] Page;
    public TowerObject[] Tower_obj;
    int CreatableMoney;
    private int currentIndex = 0;
    private void OnEnable()
    {
        for (int i = 0; i < Page.Length; i++)
        {
            Page[i].SetActive(i == 0);
        }
    }
    public void ExitMenu()
    {
        HandMenu.SetActive(false);
        GameManager.instance.playerStatus = PlayerStatus.Idle;
    }
    public void CreateTower(int a)
    {
        Debug.Log(Tower_obj[0].Money);
        if(GameManager.instance.SeletedObject == null || GameManager.instance.MyMoney < Tower_obj[a].Money)
        {
            return;
        }
        GameObject createObject = null;
        createObject = Instantiate(Tower_obj[a].TowerPrefab, GameManager.instance.SeletedObject.transform);
        createObject.transform.position = new Vector3(createObject.transform.position.x + 0.85f, createObject.transform.position.y + 1.82f, createObject.transform.position.z - 0.89f);
        GameManager.instance.MyMoney -= Tower_obj[a].Money;
        GameManager.instance.SeletedObject.layer = 15;
    }
    public void Previous_Page_btn()
    {
        Page[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + Page.Length) % Page.Length;
        Page[currentIndex].SetActive(true);
    }
    public void Next_Page_btn()
    {
        Page[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % Page.Length;
        Page[currentIndex].SetActive(true);
    }
    public void CreateMode_btn()
    {
        GameManager.instance.playerStatus = PlayerStatus.Search;
        AskMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
