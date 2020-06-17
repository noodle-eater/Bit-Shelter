using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageNode : MonoBehaviour, INodeType
{

    public NodeType Type { get; private set; }
    private Connector connector;

    private void Start() {
        Type = NodeType.Storage;
    }

    private void Update()
    {
        if(connector != null) {
            Debug.Log("Count : " + connector.OperatorNodes.Count);
            connector.OperatorNodes.ForEach((op) =>  {
                Debug.Log(op.GetResult());
                Debug.Log(op.OperatorData.NodeTag);
            });
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        connector = other.GetComponent<Connector>();
    }

    public NodeType GetNodeType()
    {
        return NodeType.Storage;
    }
}
