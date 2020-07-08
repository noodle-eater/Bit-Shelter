using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StorageNode : MonoBehaviour, INodeType, IInitOnStart
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

                if(GameConfig.Instance.currentLevel < GameConfig.Instance.maxLevel + 1) {
                    GameConfig.Instance.currentLevel++;
                }
                
                // #if DISABLE_NEXT_LEVEL
                GameObject.Find("Loading Panel").GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 1, false);

                if(GameConfig.Instance.currentLevel > GameConfig.Instance.maxLevel) {
                    FindObjectOfType<Text>().text = "Congrats!!! You Finish All the Level";
                    GameConfig.Instance.currentLevel = 1;
                    StartCoroutine(Fun.LoadSceneAsync("Main Menu"));
                } else {
                    StartCoroutine(Fun.LoadSceneAsync("Level " + GameConfig.Instance.currentLevel, 
                        OnLoading : (progress) => Debug.Log("Loading : " + progress)));
                }
                // #endif
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        slotData = other.GetComponent<OutputSlotData>().inputSlot;
    }

    public NodeType GetNodeType()
    {
        return NodeType.Storage;
    }
}
