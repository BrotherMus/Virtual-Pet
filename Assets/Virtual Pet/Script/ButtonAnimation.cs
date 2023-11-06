using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    private bool isPlaying = false; // A flag to check if the animation is currently playing

    // Assign the Animator component when the script starts
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Function to trigger the animation
    public void PlayAnimation()
    {
        // Check if the animation is not already playing
        if (!isPlaying)
        {
            animator.SetTrigger("Eat"); // Trigger the animation
            isPlaying = true; // Set the flag to true to prevent further animations until this one is done
        }
    }

    // Function to reset the animation flag (called when the animation ends)
    public void AnimationFinished()
    {
        isPlaying = false;
    }
}
