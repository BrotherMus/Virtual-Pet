using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndAnimate : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    public Animator animator; // Reference to the Animator component
    private bool isPlaying = false; // A flag to check if the animation is currently playing

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Make sure animator is assigned in the Inspector
        if (animator == null)
        {
            Debug.LogError("Animator not assigned to the DragAndAnimate script.");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Optional: Add code for any actions when the image is clicked (before dragging)
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

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

    // Check for collisions with other GameObjects
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Adjust the tag check based on your requirements
        if (other.CompareTag("DestroyZone"))
        {
            Destroy(gameObject); // Destroy this GameObject when it touches another with the specified tag
        }
    }
}
