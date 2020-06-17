using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour, IInitOnStart
{

    public List<InputNode> InputNodes { get; private set; }
    public List<OperatorNode> OperatorNodes { get; private set; }

    public void InitOnStart()
    {
        InputNodes = new List<InputNode>();
        OperatorNodes = new List<OperatorNode>();
    }

    public void AddInput(InputNode inputNode) {
        if(InputNodes.Count < 2) {
            InputNodes.Add(inputNode);
        }
    }

    public void AddOperator(OperatorNode operatorNode) {
        OperatorNodes.Add(operatorNode);
    }

}
