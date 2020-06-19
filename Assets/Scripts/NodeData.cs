using UnityEngine;

public class NodeData : MonoBehaviour, IInitOnStart
{

    public float YPosition;
    public float XPosition;
    public string NodeTag;
    public NodeType Type;
    public int Order;

    public void InitOnStart() {
        YPosition = transform.position.y;
        XPosition = transform.position.x;
        NodeTag = tag;
        Type = GetComponent<INodeType>().GetNodeType();
    }
}
