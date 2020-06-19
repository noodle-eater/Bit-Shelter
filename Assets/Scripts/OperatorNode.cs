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
        var slot = other.GetComponent<OutputSlotData>();

        if(slot != null) {
            slots.Add(slot.inputSlot);
        }
    }
    
    private void Update() {
        Debug.Log(GetResult());
    }

    public bool GetResult() {
        if(slots.Count > 1) {
            switch(comparator) {
                case OperatorType.Or : return ToBool(slots[0].Result.GetInput()) || ToBool(slots[1].Result.GetInput());
                case OperatorType.And : return ToBool(slots[0].Result.GetInput()) && ToBool(slots[1].Result.GetInput());
                // case OperatorType.Not : 
                case OperatorType.NotOr : return !(ToBool(slots[0].Result.GetInput()) || ToBool(slots[1].Result.GetInput()));
                case OperatorType.NotAnd : return !(ToBool(slots[0].Result.GetInput()) && ToBool(slots[1].Result.GetInput()));
                default : return false;
            }
        }
        return false;
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

    public int GetInput()
    {
        return Funct.ToInt(GetResult());
    }
}
