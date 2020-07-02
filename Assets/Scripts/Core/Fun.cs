using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Fun
{

    public static void ForEach<T>(System.Action<T> OnAction)
    {
        var items = FindAll<T>();
        items.ForEach((item) => OnAction?.Invoke(item));
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

    public static IEnumerator LoadSceneAsync(string sceneName, float wait = 2, System.Action<float> OnLoading = null, System.Action OnComplete = null) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        while(operation.progress < .9f) {
            OnLoading?.Invoke(operation.progress);

            yield return null;
        }
        yield return new WaitForSeconds(wait);
        OnComplete?.Invoke();
        operation.allowSceneActivation = true;
    }

    public static void When(bool condition, System.Action OnTrue, System.Action OnFalse = null) {
        if(condition) {
            OnTrue?.Invoke();
        } else {
            OnFalse?.Invoke();
        }
    }    
}