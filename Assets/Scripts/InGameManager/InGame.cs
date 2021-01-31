using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class InGame : MonoBehaviour
{

    public GameObject popUp;
    public GameObject winMenu;
    public GameObject loseMenu;
    private bool otherMenu;
    private Scene currentScene;
    public GameObject text;
    public Text t;
    


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().ActivateGameMusic();
        otherMenu = false;
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Current Scene" + currentScene.buildIndex);
        Debug.Log("SceneCountInBuildSettings: no minus " + SceneManager.sceneCountInBuildSettings);
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
            Debug.Log("Escape");
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
            GameObject.FindGameObjectWithTag("Human").GetComponent<PlayerMovement>().enabled = true;
            GameObject.FindGameObjectWithTag("Cat").GetComponent<PlayerMovement>().enabled = true;
        }
        else
        {
            DisablePlayers();
            popUp.gameObject.SetActive(true);
        }

    }

    public void PlayerDied()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        FindObjectOfType<AudioManager>().PlaySound("Fall");
        otherMenu = true;
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

    public void PlayerWin()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        FindObjectOfType<AudioManager>().PlaySound("Win");
        otherMenu = true;
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

    public void ReturnToMenu()
    {
        FindObjectOfType<AudioManager>().PlaySound("UI");
        FindObjectOfType<AudioManager>().ActivateMenuMusic();
        SceneManager.LoadScene("Menu");
    }
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
    
    public void DisablePlayers()
    {
        GameObject.FindGameObjectWithTag("Human").GetComponent<PlayerMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("Cat").GetComponent<PlayerMovement>().enabled = false;
    }

    public void PlayerMoved(int i)
    {
        text.GetComponent<Text>().text = i.ToString();
    }

}
