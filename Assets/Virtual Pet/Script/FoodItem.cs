using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float foodValue = 20.0f; // Amount of hunger this food item restores

    void OnMouseDown()
    {
        // When the player clicks on the food item, feed the pet
        //PetController pet = FindObjectOfType<PetController>();
        //if (pet != null)
       /* {
            pet.Feed(foodValue);
            Destroy(gameObject); // Remove the food item
        }*/
    }
}
