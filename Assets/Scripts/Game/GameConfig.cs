using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Bit Shelter/GameConfig", order = 0)]
public class GameConfig : ScriptableObject {
    
    public int maxLevel;
    public int currentLevel;
    public float bgmVolume;
    public float sfxVolume;

    public static GameConfig Instance {
        get {
            return Resources.Load<GameConfig>("Game Config");
        }
    }

}