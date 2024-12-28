using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueScript dialogue;
    public string[] lines;
    public Sprite icon;
    public string charName;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello!");
        if (collision.CompareTag("Player"))
        {
            dialogue.setLines(lines);
            dialogue.setIcon(icon);
            dialogue.setName(charName);
            dialogue.StartDialogue();
            gameObject.SetActive(false);
        }
    }

}
