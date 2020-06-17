using UnityEngine;

public class NodeData : MonoBehaviour
{

    public float YPosition;
    public float XPosition;
    public string NodeTag;
    public NodeType Type;

    private void Awake() {
        YPosition = transform.position.y;
        XPosition = transform.position.x;
        NodeTag = tag;
        Type = GetComponent<INodeType>().GetNodeType();
    }
}
