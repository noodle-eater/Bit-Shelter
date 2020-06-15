using UnityEngine;

public class NodeData : MonoBehaviour
{

    public float YPosition;
    public string NodeTag;
    public NodeType Type;

    private void Awake() {
        YPosition = transform.position.y;
        NodeTag = tag;
        Type = GetComponent<INodeType>().GetNodeType();
    }
}
