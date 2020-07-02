using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StorageNode : MonoBehaviour, INodeType, IInitOnStart
{

    public NodeType Type { get; private set; }

    private InputSlotData slotData;
    private bool isFinish = false;

    public void InitOnStart() {
        Type = NodeType.Storage;
    }

    private void Update() {
        if(slotData != null) {
            #if SANDBOX
            Debug.Log(slotData.Result.GetInput());
            #endif

            if(slotData.Result.GetInput() == 1 && !isFinish) {
                isFinish = true;

                if(GameConfig.Instance.currentLevel < GameConfig.Instance.maxLevel) {
                    GameConfig.Instance.currentLevel++;
                }
                
                GameObject.Find("Loading Panel").GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 1, false);

                if(GameConfig.Instance.currentLevel >= GameConfig.Instance.maxLevel) {
                    FindObjectOfType<Text>().text = "Congrats!!! You Finish All the Level";
                    StartCoroutine(Fun.LoadSceneAsync("Main Menu"));
                } else {
                    StartCoroutine(Fun.LoadSceneAsync("Level " + GameConfig.Instance.currentLevel, 
                        OnLoading : (progress) => Debug.Log("Loading : " + progress)));
                }

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
