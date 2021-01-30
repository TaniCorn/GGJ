using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject LevelSelectPanel;
    public GameObject SettingsPanel;
    public GameObject CreditsPanel;

    public enum Screen { mainMenu, levelSelect, settings, credits};
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentPanel(Screen.mainMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCurrentPanel(Screen screen)
    {
        currentScreen = screen;

        switch (currentScreen)
        {
            case Screen.mainMenu:
                MenuPanel.SetActive(true);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(false);
                break;

            case Screen.levelSelect:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(true);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(false);
                break;

            case Screen.settings:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(true);
                CreditsPanel.SetActive(false);
                break;

            case Screen.credits:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(true);
                break;

        }
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LevelSelectButtonPressed()
    {
        SetCurrentPanel(Screen.levelSelect);
    }

    public void SettingsButtonPressed()
    {
        SetCurrentPanel(Screen.settings);
    }

    public void CreditsButtonPressed()
    {
        SetCurrentPanel(Screen.credits);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void BackButtonPressed()
    {
        SetCurrentPanel(Screen.mainMenu);
    }
}
