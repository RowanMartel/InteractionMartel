using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    GameObject CurrentObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            CurrentObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            CurrentObject = null;
        }
    }

    void Interact()
    {
        if (!CurrentObject) return;

        CurrentObject.GetComponent<Interactable>().Interact();
    }
}