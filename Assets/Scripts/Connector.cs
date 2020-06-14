using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{

    public List<InputNode> InputNodes { get; private set; }
    public List<OperatorNode> OperatorNodes { get; private set; }

    private void Start() {
        InputNodes = new List<InputNode>();
        OperatorNodes = new List<OperatorNode>();
    }

    private void Update() {
        InputNodes.ForEach((input) => Debug.Log(input.IsActive));
    }

    public void AddInput(InputNode inputNode) {
        InputNodes.Add(inputNode);
    }

    public void AddOperator(OperatorNode operatorNode) {
        OperatorNodes.Add(operatorNode);
        Debug.Log("Add Nodes");
    }
}
