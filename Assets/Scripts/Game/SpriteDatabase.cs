using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteDatabase", menuName = "Bit Shelter/Sprite Database", order = 0)]
public class SpriteDatabase : ScriptableObject
{

    [SerializeField]
    private List<SpriteSwitch> database = new List<SpriteSwitch>();

    public static SpriteDatabase Load(string dbName = "SpriteDatabase")
    {
        return Resources.Load<SpriteDatabase>(dbName);
    }

    public Sprite GetSprite(string spriteName, bool active)
    {
        foreach (var item in database)
        {
            if (item.key == spriteName)
            {
                return active ? item.spriteOn : item.spriteOff;
            }
        }
        return null;
    }

}

[System.Serializable]
public class SpriteSwitch
{
    public string key;
    public Sprite spriteOn;
    public Sprite spriteOff;
}