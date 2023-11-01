using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject _OptionPanel;
    public GameObject _ProfilePanel;
    public GameObject _MenuPanel;



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
        _MenuPanel.SetActive(!_MenuPanel.activeSelf);
    }
    public void ProfilePanel()
    {
        _MenuPanel.SetActive(!_MenuPanel.activeSelf);
        _ProfilePanel.SetActive(!_ProfilePanel.activeSelf);
    }
    public void Sound()
    {
        
    }
    public void Music()
    {

    }
 
   
}

