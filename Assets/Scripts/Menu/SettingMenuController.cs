using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuController : MonoBehaviour
{

    public Slider bgmVolume;
    public Slider sfxVolume;
    public Button backButton;

    // Start is called before the first frame update
    private void Start()
    {
        bgmVolume.value = GameConfig.Instance.bgmVolume;
        sfxVolume.value = GameConfig.Instance.sfxVolume;

        bgmVolume.onValueChanged.AddListener((value) => GameConfig.Instance.bgmVolume = value);
        sfxVolume.onValueChanged.AddListener((value) => GameConfig.Instance.sfxVolume = value);

        backButton.onClick.AddListener(() => GetComponent<BackButtonController>().ChangeMenu(MenuType.Main));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
