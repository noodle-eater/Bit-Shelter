using UnityEngine;

public class StorageNode : MonoBehaviour, INodeType, IInitOnStart
{

    public NodeType Type { get; private set; }

    private InputSlotData slotData;

    public void InitOnStart() {
        Type = NodeType.Storage;
    }

    private void Update() {
        if(slotData != null) {
            Debug.Log(slotData.Result.GetInput());
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
