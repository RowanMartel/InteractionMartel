using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_2D : MonoBehaviour
{   
    [Header("Input settings:")]
    public float speedMultiplier = 5.0f;

    [Space]
    [Header("Character Stats:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public Animator animator;

    [field: HideInInspector]
    public bool talking;
    
    // Start is called before the first frame update
    void Start()
    {
        talking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (talking)
        {
            movementSpeed = 0;
            movementDirection = new Vector2(0, 0);
            rb.velocity = new Vector2(0, 0);
            animator.SetFloat("Speed", 0);
            return;
        }

        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
        Move();
        Animate();

        //Sets the idle to the last direction moved
        if (Input.GetAxis("Horizontal") >= 0.1f || Input.GetAxis("Horizontal") <= -0.1f || Input.GetAxis("Vertical") >= 0.1f || Input.GetAxis("Vertical") <= -0.1f)
        {
            animator.SetFloat("LastMoveX", Input.GetAxis("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxis("Vertical"));
        }


    }

    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * speedMultiplier;
    }

    void Animate()
    {
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementSpeed);
    }

}
