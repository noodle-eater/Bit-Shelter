using UnityEngine;
using UnityEngine.UI;

public class ChangeAllFont : MonoBehaviour, IInitOnStart
{

    public string fontName;

    public void InitOnStart()
    {
        var text = FindObjectsOfType<Text>();
        var font = UIFontConfig.Load().GetFont(fontName);

        foreach(var item in text) {
            item.font = font;
        }

        Debug.Log("Change All Font");
    }
}