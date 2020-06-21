using UnityEngine;

public class OutputSlotData : MonoBehaviour {
    
    public int result;
    public InputSlotData inputSlot;
    
    private void Update() {
        result = inputSlot.Result.GetInput();
    }
}