﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InputNode : MonoBehaviour, INodeType
{

    public bool IsActive { get; private set; }
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        IsActive = false;
    }

    private void OnMouseDown() {
        if(Input.GetMouseButton(0)) {
            IsActive = !IsActive;
            spriteRenderer.color = IsActive ? Color.yellow : Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var connector = other.GetComponent<Connector>();
        connector.AddInput(this);
        Debug.Log("Input");
    }

    public NodeType GetNodeType()
    {
        return NodeType.Input;
    }
}