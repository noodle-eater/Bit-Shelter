using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Fun
{

    public static void ForEach<T>(System.Action<T> OnAction)
    {
        var items = FindAll<T>();
        foreach (var item in items)
        {
            OnAction(item);
        }
    }

    public static List<T> FindAll<T>()
    {
        List<T> interfaces = new List<T>();
        GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var rootGameObject in rootGameObjects)
        {
            T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>();
            foreach (var childInterface in childrenInterfaces)
            {
                interfaces.Add(childInterface);
            }
        }
        return interfaces;
    }

    public static int ToInt(bool value)
    {
        return value ? 1 : 0;
    }

    public static bool ToBool(int value) {
        return value == 1;
    }
}