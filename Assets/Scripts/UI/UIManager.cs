using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject finallevel;
    public GameObject fail;
    public GameObject win;

    public GameObject menu;
    public InGameView inGame;

    public GameObject info;

    public GameObject pad;
    private void Awake()
    {
        instance = this;

#if UNITY_ANDROID || UNITY_EDITOR || UNITY_IOS
        pad.SetActive(true);
#else
        pad.SetActive(false);
#endif

    }
    public void showmenu()
    {
        menu.SetActive(true);
    }

    public void hidemenu()
    {
        menu.SetActive(false);
    }

    public void showInGame()
    {
        inGame.gameObject.SetActive(true);
        inGame.onShow();
    }

    public void showFinal()
    {
        finallevel.SetActive(true);
    }

    internal void hideFinal()
    {
        finallevel.SetActive(false);
    }

    public void showfail()
    {
        fail.SetActive(true);
    }

    internal void hidefail()
    {
        fail.SetActive(false);
    }

    internal void hideingame()
    {
        inGame.gameObject.SetActive(false);
    }

    public void showwin()
    {
        win.SetActive(true);

    }

    internal void hidewin()
    {
        win.SetActive(false);
    }
}
