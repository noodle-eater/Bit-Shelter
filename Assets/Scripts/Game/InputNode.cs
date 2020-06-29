using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InputNode : MonoBehaviour, INodeType, IInitOnStart, IInputValue
{

    public int Result;
    public bool IsActive { get; private set; }
    private SpriteRenderer spriteRenderer;
    
    public void InitOnStart() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        IsActive = false;
    }

    private void OnMouseDown() {
        if(Input.GetMouseButton(0)) {
            IsActive = !IsActive;
            spriteRenderer.color = IsActive ? Color.yellow : Color.white;
            Result = Fun.ToInt(IsActive);
        }
    }

    public NodeType GetNodeType()
    {
        return NodeType.Input;
    }

    public int GetInput()
    {
        return Result;
    }
}
