using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Health")]
    public float _Health;
    public float _MaxHealth = 100f;
    public Slider _HealthSlider;
    [Header("Hungry")]
    public float _Hungry;
    public float _MaxHungry = 100f;
    public Slider _HungrySlider;
    [Header("Energy")]
    public float _Energy;
    public float _MaxEnergy = 100f;
    public Slider _EnergySlider;
    [Header("Happiness")]
    public float _Happiness;
    public float _MaxHappiness = 100f;
    public Slider _HappinessSlider;

    [Header("Food")]
    public int _Food;
    public TextMeshProUGUI _FoodText;

    [Header("Money")]
    public int _Coin;
    public TextMeshProUGUI _CoinText;

    [Header("Panel")]
    public GameObject _ListGamesPanel;

    public void ListGamesPanel()
    {
        _ListGamesPanel.SetActive(!_ListGamesPanel.activeSelf);
    }

    private void Start()
    {
        _Health = _MaxHealth;
        _Hungry = _MaxHungry;
        _Energy = _MaxEnergy;
        _Happiness = _MaxHappiness;
    }
    //public void PlayGames()
    //{
    //    if(_Energy > 0)
    //    {
    //        _Energy--;
    //        _Hungry--;
    //        _Happiness++;
    //        _Coin++;
    //    }
    //    else
    //    {
    //        Debug.Log("Dont have Energy to play");
    //    }
    //}
    public void EatFood()
    {
        if(_Food > 0)
        {
            _Food--;
            _Hungry++;
            _Happiness++;
        }
        else
        {
            Debug.Log("Dont have Food to eat");
        }
    }
    public void BuyFood()
    {
        if(_Coin > 0)
        {
            _Coin--;
            _Food++;
        }
        else
        {
            Debug.Log("Dont enough Coin to Buy");
        }
    }

    private void Update()
    {
        _FoodText.text = _Food + "";
        _CoinText.text = _Coin + "$";
        HealhtSystem();
        HungrySystem();
        EnergySystem();
        HappinessSystem();
    }
    public void HealhtSystem()
    {
        _HealthSlider.value = _Health;
        // Ensure the attribute doesn't go below zero
        _Health = Mathf.Max(0, _Health - (0.1f * Time.deltaTime));

        // Check if the attribute has reached zero (or a minimum value), indicating a game over or a specific event.
        if (_Health <= 0)
        {
            Debug.Log("Die");
        }
    }
    public void HungrySystem()
    {
        _HungrySlider.value = _Hungry;
        // Ensure the attribute doesn't go below zero
        _Hungry = Mathf.Max(0, _Hungry - (0.1f * Time.deltaTime));

        // Check if the attribute has reached zero (or a minimum value), indicating a game over or a specific event.
        if (_Hungry <= 0)
        {
            Debug.Log("Very Hungry");
        }
    }
    public void EnergySystem()
    {
        _EnergySlider.value = _Energy;
        // Ensure the attribute doesn't go below zero
        _Energy = Mathf.Max(0, _Energy - (0.1f * Time.deltaTime));

        // Check if the attribute has reached zero (or a minimum value), indicating a game over or a specific event.
        if (_Energy <= 0)
        {
            Debug.Log("No Energy");
        }
    }
    public void HappinessSystem()
    {
        _HappinessSlider.value = _Happiness;
        // Ensure the attribute doesn't go below zero
        _Happiness = Mathf.Max(0, _Happiness - (0.1f * Time.deltaTime));

        // Check if the attribute has reached zero (or a minimum value), indicating a game over or a specific event.
        if (_Happiness <= 0)
        {
            Debug.Log("Not Happy");
        }
    }
}
