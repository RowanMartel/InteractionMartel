using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    private Queue<string> dialogue;
    private TMP_Text textElement;
    private Image image;
    private PlayerMovement_2D player;
    private bool active;
    private Interactable lastNPC;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement_2D>();
        image = GetComponentInChildren<Image>();
        textElement = GetComponentInChildren<TMP_Text>();
        dialogue = new Queue<string>();
        Deactivate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && active)
            NextLine();
    }

    public void EmptyQueue()
    {
        dialogue.Clear();
    }

    public void Queue(string line)
    {
        dialogue.Enqueue(line);
    }

    private void NextLine()
    {
        if (dialogue.Count == 0)
        {
            Deactivate();
            return;
        }
        textElement.text = dialogue.Dequeue();
    }

    public void Activate(Interactable interactable)
    {
        lastNPC = interactable;
        player.talking = true;
        active = true;
        image.enabled = true;
        NextLine();
    }
    private void Deactivate()
    {
        if (lastNPC) lastNPC.Silence();
        active = false;
        image.enabled = false;
        textElement.text = "";
        Invoke("StopTalking", 0.1f);
    }

    private void StopTalking()
    {
        player.talking = false;
    }
}