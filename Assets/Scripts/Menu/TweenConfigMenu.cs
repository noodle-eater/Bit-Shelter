using UnityEngine;

[CreateAssetMenu(fileName = "MenuTweenConfig", menuName = "Bit Shelter/MenuTweenConfig", order = 0)]
public class TweenConfigMenu : ScriptableObject
{

    [SerializeField]
    private MenuConfig mainMenu;
    [SerializeField]
    private MenuConfig aboutMenu;
    [SerializeField]
    private MenuConfig settingMenu;
    [SerializeField]
    private MenuConfig loadingMenu;

    public MenuConfig MainMenu { get => mainMenu; }
    public MenuConfig AboutMenu { get => aboutMenu; }
    public MenuConfig SettingMenu { get => settingMenu; }
    public MenuConfig LoadingMenu { get => loadingMenu; }

    public static TweenConfigMenu Instance {
        get {
            return Resources.Load<TweenConfigMenu>("MenuTweenConfig");
        }
    }
}

[System.Serializable]
public class MenuConfig
{
    public Vector2 targetPosition = Vector2.zero;
    public float duration = 0f;
    public bool snap = false;
}