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
        Debug.Log((false || false));
    }

    public bool GetResult() {
        return inputs[0].IsActive || inputs[1].IsActive;
    }
}
