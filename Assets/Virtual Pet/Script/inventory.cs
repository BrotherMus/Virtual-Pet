using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    //Pet Selection
    public GameObject[] pets; // Assign your pet prefabs to this array in the inspector.
    public int currentPetIndex = 0; // Keep track of the currently selected pet.

    public GameObject[] _pets; // Assign your pet prefabs to this array in the inspector.


    void Start()
    {
        // Initialize by showing the first pet and hiding the rest.
        ShowPet(currentPetIndex);
    }
    private void Update()
    {
        ShowPets(currentPetIndex);
    }

    public void NextPet()
    {
        // Hide the current pet.
        HidePet(currentPetIndex);

        // Move to the next pet.
        currentPetIndex = (currentPetIndex + 1) % pets.Length;

        // Show the new pet.
        ShowPet(currentPetIndex);
    }
    public void PreviousPet()
    {
        // Hide the current pet.
        HidePet(currentPetIndex);

        // Move to the previous pet.
        currentPetIndex = (currentPetIndex - 1 + pets.Length) % pets.Length;

        // Show the new pet.
        ShowPet(currentPetIndex);
    }

    private void ShowPet(int petIndex)
    {
        if (petIndex >= 0 && petIndex < pets.Length)
        {
            pets[petIndex].SetActive(true);
        }
    }
    public void ShowPets(int petIndex)
    {
        for (int i = 0; i < _pets.Length; i++)
        {
            if (i == petIndex)
            {
                _pets[i].SetActive(true);
            }
            else
            {
                _pets[i].SetActive(false);
            }
        }

    }
        private void HidePet(int petIndex)
    {
        if (petIndex >= 0 && petIndex < pets.Length)
        {
            pets[petIndex].SetActive(false);
        }
    }
}
