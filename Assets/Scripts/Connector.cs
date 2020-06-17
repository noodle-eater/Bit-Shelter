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

    public void AddInput(InputNode inputNode) {
        InputNodes.Add(inputNode);
    }

    public void AddOperator(OperatorNode operatorNode) {
        OperatorNodes.Add(operatorNode);
    }
}
