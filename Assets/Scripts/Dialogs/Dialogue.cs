using System.Collections;
using System.Collections.Generic;
using InventorySystem.Item;
using UnityEngine;

[System.Serializable]

public class Dialogue
{
    public string name;
    [TextArea(3, 10)]
    public string[] sentecesWithoutInstrument;

    public ItemData instrument;
    [TextArea(3, 10)]
    public string[] sentecesWithInstrument;
}
