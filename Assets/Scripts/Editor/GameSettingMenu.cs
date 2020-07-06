using UnityEditor;
using UnityEngine;

public class GameSettingMenu {
    
    [MenuItem("Game/Set Environment to Sandbox")]
    public static void SetEnvironmentToSandbox() {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL, "SANDBOX");
        Debug.Log("<color=green>Environment is set to Sandbox</color>");
    }

    [MenuItem("Game/Set Environment to Production")]
    public static void SetEnvironmentToProduction() {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL, "PRODUCTION");
        Debug.Log("<color=green>Environment is set to Production</color>");
    }

    [MenuItem("Game/Disable Load Next Level")]
    public static void DisableLoadNextLevel() {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL, "SANDBOX;DISABLE_NEXT_LEVEL");
        Debug.Log("<color=green>Environment is set to Production</color>");
    }

    [MenuItem("Game/Reset GameConfig")]
    public static void ResetGameConfig() {
        GameConfig.Instance.bgmVolume = 1;
        GameConfig.Instance.sfxVolume = 1;
        GameConfig.Instance.currentLevel = 1;
    }

}