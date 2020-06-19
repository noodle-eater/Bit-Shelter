using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour, IInitOnStart
{

    public InputSlotData inputSlot;
    public InputSlotData OutputSlot;

    public void InitOnStart()
    {
        // value = inputSlot.Result.GetInput();
    }

}
