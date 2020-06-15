using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeDataManager : MonoBehaviour {
    
    public List<NodeData> nodes = new List<NodeData>();
    public Dictionary<string, int> stackOrder = new Dictionary<string, int>();

    private int stackOrderCounter = 0;

    private void Start() {
        nodes = FindObjectsOfType<NodeData>().ToList();
        // TODO: Sort nodes by Y
        SetStackOrder();
    }

    private void SetStackOrder() {
        nodes.ForEach((node) => {
            Debug.Log(node.YPosition);
            if(node.NodeTag == "Untagged") {
                switch(node.Type) {
                    case NodeType.Input : node.NodeTag = NodeType.Input.ToString(); break;
                    case NodeType.Operator : node.NodeTag = NodeType.Operator.ToString() + node.YPosition; break;
                    case NodeType.Storage : node.NodeTag = NodeType.Storage.ToString(); break;
                }
            }
            if(!stackOrder.ContainsKey(node.NodeTag)) {
                stackOrder.Add(node.NodeTag, stackOrderCounter++);
            }
        });
    }
}