using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuComponent : MonoBehaviour
{
    //variables
    [SerializeField]
    private Button CloseButton;
    [SerializeField]
    private MenuChangeButton[] ChangeButtons;

    //unity calls + setup 
    private void Start()
    {
        ChangeButtons = gameObject.GetComponentsInChildren<MenuChangeButton>();
        CloseButton?.onClick?.AddListener(OnClick_CloseButton);
        foreach (MenuChangeButton button in ChangeButtons)
        {
            button.GetComponent<Button>().onClick.AddListener(ChangePanelReq);
        }
    }

    //user calls
    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }
    private void OnClick_CloseButton()
    {
        gameObject.GetComponentInParent<MenuManager>().
            ShowTopMenu();
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
    private void ChangePanelReq()
    {
        gameObject.GetComponentInParent<MenuManager>()
            .ShowPanel(
            EventSystem.current.currentSelectedGameObject
                .GetComponent<MenuChangeButton>().ChangeTo
            );
    }
}
