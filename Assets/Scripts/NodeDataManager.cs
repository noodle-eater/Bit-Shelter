using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeDataManager : MonoBehaviour, IInitOnStart
{

    public List<NodeData> nodes = new List<NodeData>();
    // public Dictionary<string, int> stackOrder = new Dictionary<string, int>();
    public List<StackOrder> stackOrders = new List<StackOrder>();

    private int stackOrderCounter = 0;
    private NodeData swap;

    public void InitOnStart()
    {
        nodes = FindObjectsOfType<NodeData>().ToList();
        SortNodeData();
        SetStackOrder();
    }

    public int GetOrder(string key)
    {
        int order = 0;
        stackOrders.ForEach((item) =>
        {
            if (item.Key == key)
            {
                order = item.Order;
            }
        });
        return order;
    }

    public bool IsLastOperator(string key)
    {
        int order = GetOrder(key);
        return GetOrder(key) == stackOrders.Count - 2;
    }

    private void SetStackOrder()
    {
        nodes.ForEach((node) =>
        {
            if (node.NodeTag == "Untagged")
            {
                switch (node.Type)
                {
                    case NodeType.Input: node.NodeTag = NodeType.Input.ToString() + node.XPosition; break;
                    case NodeType.Operator: node.NodeTag = NodeType.Operator.ToString() + node.YPosition; break;
                    case NodeType.Storage: node.NodeTag = NodeType.Storage.ToString() + node.XPosition; break;
                }
            }
            int order = 0;
            if (node.Type != NodeType.Input)
            {
                order = ++stackOrderCounter;
            }
            stackOrders.Add(new StackOrder { Key = node.NodeTag, Order = order, Node = node });
            node.Order = order;
        });
    }

    private void SortNodeData()
    {
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            if (nodes[i].YPosition < nodes[i + 1].YPosition)
            {
                swap = nodes[i];
                nodes[i] = nodes[i + 1];
                nodes[i + 1] = swap;
            }
        }
    }

}