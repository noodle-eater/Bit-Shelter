using System.Linq;
using UnityEngine;

public class InitializerSystem : MonoBehaviour
{
    private void Awake() {
        
    }

    private void Start() {
        FindObjectsOfType<InputNode>().ToList().ForEach((input) => input.InitOnStart());
        FindObjectsOfType<OperatorNode>().ToList().ForEach((op) => op.InitOnStart());
        FindObjectsOfType<StorageNode>().ToList().ForEach((storage) => storage.InitOnStart());
        FindObjectsOfType<NodeData>().ToList().ForEach((node) => node.InitOnStart());
        FindObjectOfType<NodeDataManager>().InitOnStart();
        FindObjectsOfType<Connector>().ToList().ForEach((connector) => connector.InitOnStart());
    }
}
