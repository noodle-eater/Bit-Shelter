using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class BackButtonController : MonoBehaviour
{

    public RectTransform mainMenu;
    public RectTransform settingMenu;
    public RectTransform aboutMenu;
    public RectTransform loadingMenu;

    private MenuType currentType;
    private TweenConfigMenu tweenConfig;

    private void Awake()
    {
        tweenConfig = TweenConfigMenu.Instance;
    }
    public void ChangeMenu(MenuType type)
    {
        switch (type)
        {
            case MenuType.About:
                aboutMenu.DOAnchorPos(Vector2.zero, 1, false);
                mainMenu.DOAnchorPos(new Vector2(-800, 0), 1, false);
                break;
            case MenuType.Setting:
                settingMenu.DOAnchorPos(Vector2.zero, 1, false);
                mainMenu.DOAnchorPos(new Vector2(800, 0), 1, false);
                break;
            case MenuType.Main:
                mainMenu.DOAnchorPos(Vector2.zero, 1, false);
                switch (currentType)
                {
                    case MenuType.About:
                        aboutMenu.DOAnchorPos(new Vector2(800, 0), 1, false);
                        break;
                    case MenuType.Setting:
                        settingMenu.DOAnchorPos(new Vector2(-800, 0), 1, false);
                        break;
                }
                break;
            case MenuType.Loading:
                loadingMenu.DOAnchorPos(Vector2.zero, 1, false);
                mainMenu.DOAnchorPos(new Vector2(0, -450), 1, false);
                break;
        }

        currentType = type;
    }

    private void ChangeMenu(ref RectTransform rect, MenuConfig config)
    {
        rect.DOAnchorPos(config.targetPosition, config.duration, config.snap);
    }
}
