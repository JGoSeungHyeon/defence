using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskMenu : MonoBehaviour
{ 
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.playerStatus != PlayerStatus.Search)
        {
            gameObject.SetActive(false);
        }
    }
}
