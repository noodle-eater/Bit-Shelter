using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackButtonController : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject aboutMenu;
    public MenuType menuType;

    public void ChangeMenu(MenuType type) {
        menuType = type;

        switch(type) {
            case MenuType.About: 
                aboutMenu.SetActive(true);
                settingMenu.SetActive(false);
                mainMenu.SetActive(false);
                break;
            case MenuType.Setting:
                settingMenu.SetActive(true);
                aboutMenu.SetActive(false);
                mainMenu.SetActive(false);
                break;
            case MenuType.Main:
                mainMenu.SetActive(true);
                settingMenu.SetActive(false);
                aboutMenu.SetActive(false);
                break;
        }
    }

}
