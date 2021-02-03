using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region Variables and Objects
    [Header("All Panels")]
    public GameObject MenuPanel;
    [Space]
    public GameObject LevelSelectPanel;
    public Scrollbar LevelScrollBar;
    private float levelAmount = 10;//used for the scrollbar in levels, however the maths is wrong but it still works with incorrect numbers
    public Image LevelScrollBox;
    public int levelNumberSelected = 1;
    public GameObject levelName;
    [Space]
    public GameObject SettingsPanel;
    public GameObject CreditsPanel;
    public GameObject ControlsPanel;

    public enum Screen { mainMenu, levelSelect, settings, credits, controls };
    Screen currentScreen;
    //Screen previousScreen;
    #endregion

    #region deadVars
    //public float transitionSpeed;
    //public float transitionWait;
    //public Vector2 transitionDirection;
    //public Vector2 windowSize;
    //public float transitionTimer;
    //public Vector2 transitionStart;
    //public Vector2 transitionEnd;
    //public bool isTransitioning;
    #endregion



    //Initialisations
    void Start()
    {
        levelNumberSelected = 1;
        SetCurrentPanel(Screen.mainMenu);//Starts with main screen

        #region dedTransition
        //transitionSpeed = 2;
        //transitionWait = 5;
        //transitionDirection = new Vector2(1, 0);
        //windowSize = new Vector2(1920f, 1080f);
        //isTransitioning = false;
        #endregion
    }
    #region deadCodeTransition
    // Update is called once per frame
    //void Update()
    //{
    //if (transitionTimer > transitionWait)
    //{
    //    isTransitioning = false;
    //}
    //}

    //private void FixedUpdate()
    //{
    //    if (isTransitioning)
    //    {
    //        transitionTimer += Time.deltaTime * transitionSpeed;
    //        setPanelPosition(currentScreen, new Vector2(Mathf.Lerp(transitionStart.x, transitionEnd.x, Mathf.Clamp(transitionTimer, 0, 1)), Mathf.Lerp(transitionStart.y, transitionEnd.y, Mathf.Clamp(transitionTimer, 0, 1))));
    //    }
    //}
    #endregion

    /// <summary>
    /// Sets the screen to specified screen. This system uses panels that have to be referenced and coded in. Room for improvement later but really good
    /// </summary>
    /// <param name="screen"></param>
    public void SetCurrentPanel(Screen screen)
    {
        FindObjectOfType<AudioManager>().PlaySound("UI");
        //previousScreen = currentScreen;
        currentScreen = screen;

        switch (currentScreen)
        {
            case Screen.mainMenu:
                MenuPanel.SetActive(true);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(false);
                ControlsPanel.SetActive(false);
                //beginTransition();
                break;

            case Screen.levelSelect:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(true);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(false);
                ControlsPanel.SetActive(false);
                //beginTransition();
                break;

            case Screen.settings:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(true);
                CreditsPanel.SetActive(false);
                ControlsPanel.SetActive(false);
                //beginTransition();
                break;

            case Screen.credits:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(true);
                ControlsPanel.SetActive(false);
                //beginTransition();
                break;
            case Screen.controls:
                MenuPanel.SetActive(false);
                LevelSelectPanel.SetActive(false);
                SettingsPanel.SetActive(false);
                CreditsPanel.SetActive(false);
                ControlsPanel.SetActive(true);
                break;
        }
    }
    #region Dead Code
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
    #endregion

    #region buttons
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Level1");
        FindObjectOfType<AudioManager>().PlaySound("UI");
    }
    public void LevelSelectButtonPressed()
    {
        SetCurrentPanel(Screen.levelSelect);
        FindObjectOfType<AudioManager>().PlaySound("UI");
    }
    public void SettingsButtonPressed()
    {
        SetCurrentPanel(Screen.settings);
        FindObjectOfType<AudioManager>().PlaySound("UI");
    }
    public void CreditsButtonPressed()
    {
        SetCurrentPanel(Screen.credits);
        FindObjectOfType<AudioManager>().PlaySound("UI");
    }
    public void QuitButtonPressed()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().PlaySound("UI");
    }
    public void ControlButtonPressed()
    {
        SetCurrentPanel(Screen.controls);
        FindObjectOfType<AudioManager>().PlaySound("UI");
    }
    //general back button
    public void BackButtonPressed()
    {
        SetCurrentPanel(Screen.mainMenu);
        FindObjectOfType<AudioManager>().PlaySound("UI");
    }
    #endregion

    #region level Functions
    public void LevelScrollbarScrolled()
    {
        LevelScrollBox.rectTransform.anchoredPosition = new Vector2(4040 - (LevelScrollBar.value * levelAmount * 350), 12);//Changes position with formula hard coded
        Debug.Log(new Vector2(4040 - (LevelScrollBar.value * levelAmount * 350), 12));
    }
    public void LevelSelect(int levelSelected)
    {
        levelNumberSelected = levelSelected;
        FindObjectOfType<AudioManager>().PlaySound("UI");
    }
    public void LevelSelectString(string textToReplace)
    {
        levelName.gameObject.GetComponent<Text>().text = textToReplace;
    }
    public void PlaySelected()
    {
        FindObjectOfType<AudioManager>().PlaySound("UI");
        SceneManager.LoadScene(levelNumberSelected);
    }
    #endregion
}
