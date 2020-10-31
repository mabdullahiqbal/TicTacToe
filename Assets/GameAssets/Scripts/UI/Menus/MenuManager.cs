using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //variables
    [SerializeField]
    private MenuComponent[] Menus;
    public bool ShowLoadingScreen;
    private Stack<MenuName> menuStack;

    //unity calls
    private void Start()
    {
        menuStack = new Stack<MenuName>();
        ShowPanel(MenuName.MainMenu);
    }
    //user calls
    public void ShowPanel(MenuName menu)
    {        
        CloseAllPanels();
        menuStack.Push(menu);
        Menus[(int)menu].ShowPanel();
    }
    private void CloseAllPanels()
    {        
        foreach (MenuComponent menu in Menus)
        {
            menu.ClosePanel();
        }
    }
    public void ShowTopMenu()
    {
        if (menuStack.Count > 1)
        {
            Menus[(int)menuStack.Pop()].ClosePanel();
            Menus[(int)menuStack.Peek()].ShowPanel();
        }
    }
}

[Serializable]
public enum MenuName
{
    MainMenu,    
    NewGame,
    Multiplayer,
    Settings
}