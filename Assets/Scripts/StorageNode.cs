using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageNode : MonoBehaviour
{

    private Connector connector;

    // Update is called once per frame
    void Update()
    {
        if(connector != null)
            connector.OperatorNodes.ForEach((op) => Debug.Log(op.GetResult()));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        connector = other.GetComponent<Connector>();
        Debug.Log("Storage");
    }
}
