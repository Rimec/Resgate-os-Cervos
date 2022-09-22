using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Start()
    {
        if(GameManager.instance.GetLost){
            GameObject.FindObjectOfType<ScreensManager>()?.ShowLoseScreen();
        }
        if(GameManager.instance.GetHasWon){
            GameObject.FindObjectOfType<ScreensManager>()?.ShowWinScreen();
        }
    }
}
