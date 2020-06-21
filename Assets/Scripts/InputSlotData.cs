using UnityEngine;

public class InputSlotData : MonoBehaviour {
    
    public int resultValue = 0;
    public IInputValue Result;

    private void Update() {
        if(Result != null) {
            resultValue = Result.GetInput();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Result = other.GetComponent<IInputValue>();
    }

}