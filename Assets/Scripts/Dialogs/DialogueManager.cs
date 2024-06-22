using System.Collections;
using System.Collections.Generic;
using Actors.Player;
using InventorySystem;
using MiniGames;
using MiniGames.AxeClicker;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;

    public Animator boxAnim;
    public Animator startAnim;

    private Queue<string> sentences;
    private Inventory _inventory;
    private MiniGamesManager _miniGamesManager;
    private Dialogue _currentDialogue;

    private void Start()
    {
        sentences = new Queue<string>();
        _inventory = ServiceLocator.Instance.Get<PlayerCharacter>().Inventory;
        _miniGamesManager = ServiceLocator.Instance.Get<MiniGamesManager>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _currentDialogue = dialogue;
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);

        nameText.text = dialogue.name;
        sentences.Clear();

        if (_inventory.IsHaveItem(dialogue.instrument))
        {
            foreach (string sentence in dialogue.sentecesWithInstrument)
            {
                sentences.Enqueue(sentence);
            }

        }
        else
        {
            foreach (string sentence in dialogue.sentecesWithoutInstrument)
            {
                sentences.Enqueue(sentence);
            }
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        if (_currentDialogue !=  null && _inventory.IsHaveItem(_currentDialogue.instrument)) 
        {
            _miniGamesManager.StartGame<AxeClicker>();
        }

        boxAnim.SetBool("boxOpen", false);
    }
}
