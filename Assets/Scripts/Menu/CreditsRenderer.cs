using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsRenderer : MonoBehaviour, IInitOnStart
{

    [SerializeField]
    private Text aboutText;
    [SerializeField]
    private TextAsset creditsFile;

    public void InitOnStart()
    {
        aboutText.text = creditsFile.text;    
    }
}
