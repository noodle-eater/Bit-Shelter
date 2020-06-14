using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageNode : MonoBehaviour
{

    private OperatorNode operatorNode;

    // Start is called before the first frame update
    void Start()
    {
        operatorNode = FindObjectOfType<OperatorNode>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(operatorNode.GetResult());
    }
}
