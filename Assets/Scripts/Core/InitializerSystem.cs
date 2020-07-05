using UnityEngine;

public class InitializerSystem : MonoBehaviour
{
    private void Awake()
    {
        Fun.ForEach<IInitOnAwake>((item) => item.InitOnAwake());
    }

    private void Start()
    {
        Fun.ForEach<IInitOnStart>((item) => item.InitOnStart());
    }
}
