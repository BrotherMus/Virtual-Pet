using System;
using UnityEngine;

public class DragAndAnimateSprite : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    public Animator animator; // Reference to the Animator component

    public AudioSource audioPlayer;

    void Update()
    {
        // Check for mouse/touch input
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            // Check if the clicked point is over the sprite
            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                isDragging = true;
                offset = transform.position - mousePosition;
            }
        }

        if (isDragging)
        {
            // Update the position of the sprite while dragging
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
        }

        // Check for the end of drag
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;

            // Check if the sprite is touching the Animator object
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<Animator>() == animator)
                {
                    audioPlayer.Play();
                    // Trigger the animation
                    animator.Play("Eat");

                   

                    // Destroy the sprite
                    Invoke("DestroySprite", 1f);
                    break;
                }
            }
        }
    }

    // Function to destroy the sprite
    void DestroySprite()
    {
        Destroy(gameObject);
    }



}
