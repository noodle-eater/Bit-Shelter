using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InputNode : MonoBehaviour, IInitOnStart, IInputValue
{

    public int Result;
    public bool isActive;
    private AudioPlayer audioPlayer;
    private SpriteRenderer spriteRenderer;
    public bool IsActive { get => isActive; }
    
    public void InitOnStart() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        UpdateInput();
    }

    private void OnMouseDown() {
        if(Input.GetMouseButton(0))
        {
            isActive = !IsActive;
            audioPlayer.PlaySwitch();
            UpdateInput();
        }
    }

    private void UpdateInput() {
        spriteRenderer.sprite = SpriteDatabase.Load().GetSprite("switch", isActive);
        Result = Fun.ToInt(isActive);
    }

    public int GetInput()
    {
        return Result;
    }
}
