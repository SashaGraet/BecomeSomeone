using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem.Item;

public class DialogueTriger : MonoBehaviour
{
    public Dialogue dialogue;
    private void OnValidate()
    {
        if (dialogue != null && dialogue.instrument != null && dialogue.instrument.type != ItemType.Tool)
        {
            dialogue.instrument = null;
            Debug.LogError("Item is not instrument");
        }
    }

    public void TrigerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
