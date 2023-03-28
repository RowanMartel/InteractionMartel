using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private enum Types
    {
        nothing,
        pickup,
        info,
        dialogue
    }

    [SerializeField]
    private Types type;
    [SerializeField]
    private string info;
    [SerializeField]
    private List<string> dialogue;

    private InfoBubble infoBubble;
    private DialogueBox dialogueBox;
    private PlayerMovement_2D player;
    private Animator animator;

    private void Start()
    {
        infoBubble = FindObjectOfType<InfoBubble>();
        dialogueBox = FindObjectOfType<DialogueBox>();
        player = FindObjectOfType<PlayerMovement_2D>();
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (player.talking) return;
        switch(type)
        {
            case Types.nothing:
                Nothing();
                break;
            case Types.pickup:
                Pickup();
                break;
            case Types.info:
                Info();
                break;
            case Types.dialogue:
                Dialogue();
                break;
        }
    }

    void Nothing()
    {
        Debug.Log("Object type is nothing, so nothing happened...");
    }
    void Pickup()
    {
        Debug.Log("Object type is pickup, so it's been picked up");
        Remove();
    }
    void Info()
    {
        Debug.Log("Object type is info, so here's some info: fish never stop growing");
        infoBubble.ShowInfo(info);
    }
    void Dialogue()
    {
        Debug.Log("Object type is dialogue, so the dialogue box will open");
        dialogueBox.EmptyQueue();
        foreach (string line in dialogue)
        {
            dialogueBox.Queue(line);
        }
        dialogueBox.Activate(this);
        animator.SetBool("talking", true);
    }

    void Remove()
    {
        gameObject.SetActive(false);
    }

    public void Silence()
    {
        animator.SetBool("talking", false);
    }
}