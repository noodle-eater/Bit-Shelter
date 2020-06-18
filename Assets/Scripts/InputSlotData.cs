using UnityEngine;

public class InputSlotData : MonoBehaviour {
    
    public int resultValue = 0;
    public SlotType type;
    public IInputValue Result;

    private void OnTriggerEnter2D(Collider2D other) {
        Result = other.GetComponent<IInputValue>();
    }

}