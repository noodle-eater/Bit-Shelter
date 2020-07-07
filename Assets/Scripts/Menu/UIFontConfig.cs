using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIFontConfig", menuName = "Bit Shelter/UIFontConfig", order = 0)]
public class UIFontConfig : ScriptableObject {
    
    [SerializeField]
    private List<FontData> database = new List<FontData>();

    public static UIFontConfig Load(string configName = "UIFontConfig") {
        return Resources.Load<UIFontConfig>(configName);
    }

    public Font GetFont(string fontName) {
        foreach(var item in database) {
            if(item.fontName == fontName) {
                return item.font;
            }
        }
        return new Font();
    }

}

[System.Serializable]
public class FontData {
    public string fontName;
    public Font font;
}