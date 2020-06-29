﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    public Button playButton;
    public Button settingButton;
    public Button aboutButton;
    public Text levelSelect;
    public Button reduceButton;
    public Button addButton;
    public Button backAboutButton;

    private int levelNumber = 1;
    private BackButtonController back;

    private void Start()
    {
        back = GetComponent<BackButtonController>();

        playButton.onClick.AddListener(() => SceneManager.LoadScene("Level " + levelNumber));
        settingButton.onClick.AddListener(() => back.ChangeMenu(MenuType.Setting));
        aboutButton.onClick.AddListener(() => back.ChangeMenu(MenuType.About));
        backAboutButton.onClick.AddListener(() => back.ChangeMenu(MenuType.Main));
        addButton.onClick.AddListener(() => { levelNumber++; levelSelect.text = levelNumber.ToString(); });
        reduceButton.onClick.AddListener(() => { 
            if(levelNumber > 1) {
                levelNumber--; 
                levelSelect.text = levelNumber.ToString(); 
            }
        });
    }

}
