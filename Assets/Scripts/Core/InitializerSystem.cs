using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializerSystem : MonoBehaviour
{
    private void Awake()
    {
        Funct.ForEach<IInitOnAwake>((item) => item.InitOnAwake());
    }

    private void Start()
    {
        Funct.ForEach<IInitOnStart>((item) => item.InitOnStart());
    }




}
