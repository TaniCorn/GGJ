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

    public Scrollbar LevelScrollBar;
    public Image LevelScrollBox;

    //public float transitionSpeed;
    //public float transitionWait;
    //public Vector2 transitionDirection;
    //public Vector2 windowSize;
    //public float transitionTimer;
    //public Vector2 transitionStart;
    //public Vector2 transitionEnd;
    //public bool isTransitioning;

    public enum Screen { mainMenu, levelSelect, settings, credits};
    Screen currentScreen;
    Screen previousScreen;

    float levelAmount = 5;

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentPanel(Screen.mainMenu);

        //transitionSpeed = 2;
        //transitionWait = 5;
        //transitionDirection = new Vector2(1, 0);
        //windowSize = new Vector2(1920f, 1080f);
        //isTransitioning = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (transitionTimer > transitionWait)
        //{
        //    isTransitioning = false;
        //}
    }

    //private void FixedUpdate()
    //{
    //    if (isTransitioning)
    //    {
    //        transitionTimer += Time.deltaTime * transitionSpeed;
    //        setPanelPosition(currentScreen, new Vector2(Mathf.Lerp(transitionStart.x, transitionEnd.x, Mathf.Clamp(transitionTimer, 0, 1)), Mathf.Lerp(transitionStart.y, transitionEnd.y, Mathf.Clamp(transitionTimer, 0, 1))));
    //    }
    //}

    public void SetCurrentPanel(Screen screen)
    {
        previousScreen = currentScreen;
        currentScreen = screen;

        switch (currentScreen)
        {
            case Screen.mainMenu:
                MenuPanel.SetActive(true);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(false);
                //beginTransition();
                break;

            case Screen.levelSelect:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(true);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(false);
                //beginTransition();
                break;

            case Screen.settings:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(true);
                CreditsPanel.SetActive(false);
                //beginTransition();
                break;

            case Screen.credits:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(true);
                //beginTransition();
                break;

        }
    }
    //public void setPanelPosition(Screen screen, Vector2 position)
    //{
    //    switch (screen)
    //    {
    //        case Screen.mainMenu:
    //            MenuPanel.transform.position.Set(position.x, position.y, MenuPanel.transform.position.z);
    //            break;

    //        case Screen.levelSelect:
    //            LevelSelectPanel.transform.position.Set(position.x, position.y, LevelSelectPanel.transform.position.z);
    //            break;

    //        case Screen.settings:
    //            SettingsPanel.transform.position.Set(position.x, position.y, SettingsPanel.transform.position.z);
    //            break;

    //        case Screen.credits:
    //            CreditsPanel.transform.position.Set(position.x, position.y, CreditsPanel.transform.position.z);
    //            break;

    //    }
    //}

    //public Vector2 getPanelPosition(Screen screen)
    //{
    //    switch (screen)
    //    {
    //        case Screen.mainMenu:
    //            return new Vector2(MenuPanel.transform.position.x, MenuPanel.transform.position.y);

    //        case Screen.levelSelect:
    //            return new Vector2(LevelSelectPanel.transform.position.x, LevelSelectPanel.transform.position.y);

    //        case Screen.settings:
    //            return new Vector2(SettingsPanel.transform.position.x, SettingsPanel.transform.position.y);

    //        case Screen.credits:
    //            return new Vector2(CreditsPanel.transform.position.x, CreditsPanel.transform.position.y);
    //    }
    //    return new Vector2(0, 0);
    //}
    //public void beginTransition()
    //{
    //    if (isTransitioning == false)
    //    {
    //        transitionTimer = 0;
    //        transitionStart = getPanelPosition(currentScreen);
    //        transitionEnd = getPanelPosition(currentScreen) + (transitionDirection * windowSize);
    //        isTransitioning = true;
    //    }
    //}

    //main menu puttons
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

    //general back button
    public void BackButtonPressed()
    {
        SetCurrentPanel(Screen.mainMenu);
    }

    //level select buttons
    public void LevelScrollbarScrolled()
    {
        LevelScrollBox.rectTransform.anchoredPosition = new Vector2(4040 - (LevelScrollBar.value * levelAmount * 350), 12);
    }
}
