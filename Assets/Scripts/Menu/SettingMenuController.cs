using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuController : MonoBehaviour
{

    public Slider bgmVolume;
    public Slider sfxVolume;
    public Button backButton;
    public AudioPlayer audioPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();

        bgmVolume.value = GlobalConfig.BgmVolume;
        sfxVolume.value = GlobalConfig.SfxVolume;

        bgmVolume.onValueChanged.AddListener((value) =>
        {
            GlobalConfig.BgmVolume = value;
            audioPlayer.SetVolume();
        });
        sfxVolume.onValueChanged.AddListener((value) =>
        {
            GlobalConfig.SfxVolume = value;
            audioPlayer.SetVolume();
        });

        backButton.onClick.AddListener(() => GetComponent<BackButtonController>().ChangeMenu(MenuType.Main));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
