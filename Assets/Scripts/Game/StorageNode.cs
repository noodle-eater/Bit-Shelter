using DG.Tweening;
using UnityEngine;

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
            Debug.Log(slotData.Result.GetInput());

            if(slotData.Result.GetInput() == 1 && !isFinish) {
                isFinish = true;

                if(GameConfig.Instance.currentLevel < GameConfig.Instance.maxLevel) {
                    GameConfig.Instance.currentLevel++;
                }
                
                GameObject.Find("Loading Panel").GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 1, false);
                StartCoroutine(Fun.LoadSceneAsync("Level " + GameConfig.Instance.currentLevel, 
                    OnLoading : (progress) => Debug.Log("Loading : " + progress)));
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
