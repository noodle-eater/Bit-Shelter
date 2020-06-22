using UnityEngine;
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

    private int levelNumber = 1;

    private void Start()
    {
        playButton.onClick.AddListener(() => SceneManager.LoadScene("Level " + levelNumber));
        settingButton.onClick.AddListener(() => Debug.Log("Open Setting"));
        aboutButton.onClick.AddListener(() => Debug.Log("About Button"));
        addButton.onClick.AddListener(() => { levelNumber++; levelSelect.text = levelNumber.ToString(); });
        reduceButton.onClick.AddListener(() => { 
            if(levelNumber > 1) {
                levelNumber--; 
                levelSelect.text = levelNumber.ToString(); 
            }
        });
    }

}
