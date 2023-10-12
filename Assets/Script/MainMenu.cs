using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject _OptionPanel;
    public GameObject _ProfilePanel;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenus()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OptionPanel()
    {
        _OptionPanel.SetActive(!_OptionPanel.activeSelf);
    }
    public void ProfilePanel()
    {
        _ProfilePanel.SetActive(!_ProfilePanel.activeSelf);
    }
}

