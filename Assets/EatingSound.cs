using UnityEngine;

public class EatingSound : MonoBehaviour
{
    public AudioClip eatingSound;
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Assign the collision sound clip
        audioSource.clip = eatingSound;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Play the collision sound when a collision occurs
        audioSource.Play();
    }
}
