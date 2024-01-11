using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private GameObject HandMenu;
    [SerializeField] private GameObject AskMenu;
    [SerializeField] private GameObject CrossbowTower;
    [SerializeField] private GameObject DracoTower;
    [SerializeField] private GameObject ElectricTower;
    [SerializeField] private GameObject SplashTower;
    [SerializeField] private GameObject BalistaTower;
    [SerializeField] private GameObject SandglassTower;
    [SerializeField] private GameObject[] Page;
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
        if(GameManager.instance.SeletedObject == null)
        {
            return;
        }
        GameObject createObject = null;
        switch (a)
        {

            case 0 :
                createObject = Instantiate(CrossbowTower, GameManager.instance.SeletedObject.transform);
                break;
            case 1:
                createObject = Instantiate(DracoTower, GameManager.instance.SeletedObject.transform);
                break;
            case 2:
                createObject = Instantiate(ElectricTower, GameManager.instance.SeletedObject.transform);
                break;
            case 3:
                createObject = Instantiate(SplashTower, GameManager.instance.SeletedObject.transform);
                break;
            case 4:
                createObject = Instantiate(BalistaTower, GameManager.instance.SeletedObject.transform);
                break;
            case 5:
                createObject = Instantiate(SandglassTower, GameManager.instance.SeletedObject.transform);
                break;
        }
        createObject.transform.position = new Vector3(createObject.transform.position.x + 0.85f, createObject.transform.position.y + 1.82f, createObject.transform.position.z - 0.89f);
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
