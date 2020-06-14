using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorNode : MonoBehaviour
{

    private InputNode[] inputs;

    // Start is called before the first frame update
    private void Start()
    {
        inputs = FindObjectsOfType<InputNode>();
    }

    public bool GetResult() {
        return inputs[0].IsActive || inputs[1].IsActive;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var connector = other.GetComponent<Connector>();
        connector.AddOperator(this);
        Debug.Log("Operator");
    }
}
