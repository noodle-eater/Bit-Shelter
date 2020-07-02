using UnityEngine;

[CreateAssetMenu(fileName = "MenuTweenConfig", menuName = "Bit Shelter/MenuTweenConfig", order = 0)]
public class TweenConfigMenu : ScriptableObject
{

    public float duration;
    public bool snap;

    public static TweenConfigMenu Instance {
        get {
            return Resources.Load<TweenConfigMenu>("MenuTweenConfig");
        }
    }
}