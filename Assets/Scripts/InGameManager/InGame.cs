using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class InGame : MonoBehaviour
{
    [Header("Menus/UI")]
    public GameObject popUp;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject text;
    [Space]

    private bool otherMenu;//If a menu is open, limit what can be done
    private Scene currentScene;
    private int moves;


    // Initialisation
    void Start()
    {
        FindObjectOfType<AudioManager>().ActivateGameMusic();
        otherMenu = false;
        currentScene = SceneManager.GetActiveScene();
        moves = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && otherMenu == false)
        {
            RetryLevel();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && otherMenu == false)
        {
            ToggleMenu();
        }
    }

    /// <summary>
    /// OpenMenu should toggle the popup menu screen
    /// </summary>
    public void ToggleMenu()
    {
        FindObjectOfType<AudioManager>().PlaySound("UI");
        if (popUp.gameObject.activeSelf)
        {
            popUp.gameObject.SetActive(false);
            EnablePlayers();
        }
        else
        {
            DisablePlayers();
            popUp.gameObject.SetActive(true);
        }

    }

    /// <summary>
    /// When Player dies, it opens a lose menu and plays sound
    /// </summary>
    public void PlayerDied()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        FindObjectOfType<AudioManager>().PlaySound("Fall");
        otherMenu = true;//can't bring up togglemenu
        if (!loseMenu.gameObject.activeSelf)
        {
            loseMenu.gameObject.SetActive(true);
        }
        if (winMenu.gameObject.activeSelf)
        {
            winMenu.gameObject.SetActive(false);
        }
        DisablePlayers();
    }

    /// <summary>
    /// When player wins, it opens win menu and plays sound
    /// </summary>
    public void PlayerWin()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        FindObjectOfType<AudioManager>().PlaySound("Win");
        otherMenu = true;////can't bring up togglemenu
        if (!winMenu.gameObject.activeSelf)
        {
            winMenu.gameObject.SetActive(true);
        }
        if (loseMenu.gameObject.activeSelf)
        {
            loseMenu.gameObject.SetActive(false);
        }
        DisablePlayers();
    }

    /// <summary>
    /// Goes back to Main Menu
    /// </summary>
    public void ReturnToMenu()
    {
        FindObjectOfType<AudioManager>().PlaySound("UI");
        FindObjectOfType<AudioManager>().ActivateMenuMusic();
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Loads the next scene in build, if at the end, return to menu
    /// </summary>
    public void GoToNextLevel()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        FindObjectOfType<AudioManager>().PlaySound("UI");
        if (currentScene.buildIndex < (SceneManager.sceneCountInBuildSettings -1))
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        else
        {
            ReturnToMenu();
            FindObjectOfType<AudioManager>().ActivateMenuMusic();
        }
    }

    public void RetryLevel()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    
    //Disables and enables player movement script
    public void DisablePlayers()
    {
        GameObject.FindGameObjectWithTag("Human").GetComponent<PlayerMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("Cat").GetComponent<PlayerMovement>().enabled = false;
    }
    public void EnablePlayers()
    {
        GameObject.FindGameObjectWithTag("Human").GetComponent<PlayerMovement>().enabled = true;
        GameObject.FindGameObjectWithTag("Cat").GetComponent<PlayerMovement>().enabled = true;
    }

    /// <summary>
    /// Changes Moves on screen to current moves
    /// </summary>
    /// <param name="i"></param>
    public void PlayerMoved(int i)// i doesn't need to be here however it may be useful to keep it in case I want to change the parameter and it shouldn't be one.
    {
        moves = moves + i;
        text.GetComponent<Text>().text = moves.ToString();
    }

}
