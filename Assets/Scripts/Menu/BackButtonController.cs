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
                aboutMenu.DOAnchorPos(Vector2.zero, TweenConfigMenu.Instance.duration, TweenConfigMenu.Instance.snap);
                mainMenu.DOAnchorPos(new Vector2(-800, 0), TweenConfigMenu.Instance.duration, TweenConfigMenu.Instance.snap);
                break;
            case MenuType.Setting:
                settingMenu.DOAnchorPos(Vector2.zero, TweenConfigMenu.Instance.duration, TweenConfigMenu.Instance.snap);
                mainMenu.DOAnchorPos(new Vector2(800, 0), TweenConfigMenu.Instance.duration, TweenConfigMenu.Instance.snap);
                break;
            case MenuType.Main:
                mainMenu.DOAnchorPos(Vector2.zero, TweenConfigMenu.Instance.duration, TweenConfigMenu.Instance.snap);
                switch (currentType)
                {
                    case MenuType.About:
                        aboutMenu.DOAnchorPos(new Vector2(800, 0), TweenConfigMenu.Instance.duration, TweenConfigMenu.Instance.snap);
                        break;
                    case MenuType.Setting:
                        settingMenu.DOAnchorPos(new Vector2(-800, 0), TweenConfigMenu.Instance.duration, TweenConfigMenu.Instance.snap);
                        break;
                }
                break;
            case MenuType.Loading:
                loadingMenu.DOAnchorPos(Vector2.zero, TweenConfigMenu.Instance.duration, TweenConfigMenu.Instance.snap);
                mainMenu.DOAnchorPos(new Vector2(0, -450), TweenConfigMenu.Instance.duration, TweenConfigMenu.Instance.snap);
                break;
        }

        currentType = type;
    }
}
