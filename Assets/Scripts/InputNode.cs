using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InputNode : MonoBehaviour
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
}
