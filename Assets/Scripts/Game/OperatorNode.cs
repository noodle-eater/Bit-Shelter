using System.Collections.Generic;
using UnityEngine;

public class OperatorNode : MonoBehaviour, INodeType, IInputValue, IInitOnStart
{

    public OperatorType comparator;
    public List<InputSlotData> slots = new List<InputSlotData>();

    private SpriteRenderer spriteRenderer;
    private SpriteDatabase database;

    public void InitOnStart()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        database = SpriteDatabase.Load();
    }

    private void FixedUpdate()
    {
        spriteRenderer.sprite = database.GetSprite(comparator.ToString().ToLower(), GetResult());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var slot = other.GetComponent<OutputSlotData>();

        if (slot != null)
        {
            slots.Add(slot.inputSlot);
        }
    }

    public bool GetResult()
    {
        if (slots.Count > 0)
        {
            switch (comparator)
            {
                case OperatorType.Or: return ToBool(slots[0].Result.GetInput()) || ToBool(slots[1].Result.GetInput());
                case OperatorType.And: return ToBool(slots[0].Result.GetInput()) && ToBool(slots[1].Result.GetInput());
                case OperatorType.Not: return !ToBool(slots[0].Result.GetInput());
                case OperatorType.NotOr: return !(ToBool(slots[0].Result.GetInput()) || ToBool(slots[1].Result.GetInput()));
                case OperatorType.NotAnd: return !(ToBool(slots[0].Result.GetInput()) && ToBool(slots[1].Result.GetInput()));
                default: return false;
            }
        }
        return false;
    }

    public NodeType GetNodeType()
    {
        return NodeType.Operator;
    }

    private bool ToBool(int value)
    {
        return value == 1;
    }

    public int GetInput()
    {
        return Fun.ToInt(GetResult());
    }
}
