using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    [SerializeField] GameObject escapeMenu;
    [SerializeField] GameObject inGameMenu;

    private bool inGameMenuShowing = false;

    private void Start()
    {
        CallTicker();
    }

    private void ShowEscape()
    {
        escapeMenu.SetActive(true);
    }

    private void ShowInGame()
    {
        inGameMenu.SetActive(true);
    }

    private void HideAll()
    {
        escapeMenu.SetActive(false);
        inGameMenu.SetActive(false);
    }

    private void TickShowing()
    {
        HideAll();

        if (inGameMenuShowing)
        {
            ShowEscape();
            inGameMenuShowing = false;
        }
        else if (!inGameMenuShowing)
        {
            inGameMenuShowing = true;
            ShowInGame();
        }
    }

    public void CallTicker()
    {
        TickShowing();
    }
}
