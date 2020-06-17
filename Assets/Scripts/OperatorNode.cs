using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorNode : MonoBehaviour, INodeType
{

    public OperatorType comparator;
    private InputNode[] inputs;

    public NodeData OperatorData { get; private set; }

    private void Start()
    {
        inputs = FindObjectsOfType<InputNode>();
        OperatorData = GetComponent<NodeData>();
    }

    public bool GetResult() {
        switch(comparator) {
            case OperatorType.Or : return inputs[0].IsActive || inputs[1].IsActive;
            case OperatorType.And : return inputs[0].IsActive && inputs[1].IsActive;
            // case OperatorType.Not : 
            case OperatorType.NotOr : return !(inputs[0].IsActive || inputs[1].IsActive);
            case OperatorType.NotAnd : return !(inputs[0].IsActive && inputs[1].IsActive);
            default : return false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var connector = other.GetComponent<Connector>();
        connector.AddOperator(this);
    }

    public NodeType GetNodeType()
    {
        return NodeType.Operator;
    }
}
