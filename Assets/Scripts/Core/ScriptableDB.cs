using System.Collections.Generic;
using UnityEngine;

public class ScriptableDB<T> : ScriptableObject {
    
    [SerializeField]
    protected List<T> database = new List<T>();

}