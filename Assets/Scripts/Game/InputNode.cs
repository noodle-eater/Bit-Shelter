using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InputNode : MonoBehaviour, INodeType, IInitOnStart, IInputValue
{

    public int Result;
    public bool isActive;
    public bool IsActive { get => isActive; }
    private SpriteRenderer spriteRenderer;
    
    public void InitOnStart() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateInput();
    }

    private void OnMouseDown() {
        if(Input.GetMouseButton(0))
        {
            isActive = !IsActive;
            UpdateInput();
        }
    }

    private void UpdateInput() {
        // spriteRenderer.color = isActive ? Color.yellow : Color.white;
        spriteRenderer.sprite = SpriteDatabase.Load().GetSprite("switch", isActive);
        Result = Fun.ToInt(isActive);
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
