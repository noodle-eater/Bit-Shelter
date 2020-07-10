using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StorageNode : MonoBehaviour, IInitOnStart
{

    private AudioPlayer audioPlayer;
    private InputSlotData slotData;
    private bool isFinish = false;
    private SpriteDatabase database;
    private SpriteRenderer spriteRenderer;
    public NodeType Type { get; private set; }

    public void InitOnStart() {
        Type = NodeType.Storage;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        database = SpriteDatabase.Load();
    }

    private void Update() {
        if(slotData != null) {
            #if SANDBOX
            Debug.Log("Result : " + slotData.Result.GetInput());
            #endif
        
            if(spriteRenderer != null)
                spriteRenderer.sprite = database.GetSprite("lamp", Fun.ToBool(slotData.Result.GetInput()));

            if(Fun.ToBool(slotData.Result.GetInput()) && !isFinish) {
                isFinish = true;

                audioPlayer.PlayComplete();

                if(GlobalConfig.CurrentLevel < GlobalConfig.MaxLevel + 1) {
                    GlobalConfig.CurrentLevel++;
                }
                
                GameObject.Find("Loading Panel").GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 4, false);

                if(GlobalConfig.CurrentLevel > GlobalConfig.MaxLevel) {
                    FindObjectOfType<Text>().text = "Congrats!!! You Finish All the Level";
                    GlobalConfig.CurrentLevel = 1;
                    StartCoroutine(Fun.LoadSceneAsync("Main Menu", wait: 4));
                } else {
                    FindObjectOfType<Text>().text = "Loading Level " + GlobalConfig.CurrentLevel;
                    StartCoroutine(Fun.LoadSceneAsync("Level " + GlobalConfig.CurrentLevel, wait: 4));
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        slotData = other.GetComponent<OutputSlotData>().inputSlot;
    }
}
