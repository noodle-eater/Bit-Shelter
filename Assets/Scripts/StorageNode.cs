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
        if(connector != null)
            connector.OperatorNodes.ForEach((op) => Debug.Log(op.GetResult()));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        connector = other.GetComponent<Connector>();
        Debug.Log("Storage");
    }

    public NodeType GetNodeType()
    {
        return NodeType.Storage;
    }
}
