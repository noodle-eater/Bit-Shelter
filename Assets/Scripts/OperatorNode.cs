using System.Collections.Generic;
using UnityEngine;

public class OperatorNode : MonoBehaviour, INodeType, IInitOnStart, IInputValue
{

    public int Result = -1;
    public OperatorType comparator;
    public List<int> inputs = new List<int>();
    public List<InputSlotData> slots = new List<InputSlotData>();

    public NodeData OperatorData { get; private set; }

    public void InitOnStart()
    {
        OperatorData = GetComponent<NodeData>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var connector = other.GetComponent<Connector>();
        connector.AddOperator(this);
    }
    
    public bool GetResult() {
        switch(comparator) {
            case OperatorType.Or : return ToBool(inputs[0]) || ToBool(inputs[1]);
            case OperatorType.And : return ToBool(inputs[0]) && ToBool(inputs[1]);
            // case OperatorType.Not : 
            case OperatorType.NotOr : return !(ToBool(inputs[0]) || ToBool(inputs[1]));
            case OperatorType.NotAnd : return !(ToBool(inputs[0]) && ToBool(inputs[1]));
            default : return false;
        }
        
    }

    public int GetIntResult() {
        return 0;
    }

    public NodeType GetNodeType()
    {
        return NodeType.Operator;
    }

    private bool ToBool(int value) {
        return value == 1;
    }
}
