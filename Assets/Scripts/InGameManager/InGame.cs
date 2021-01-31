using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGame : MonoBehaviour
{

    public GameObject popUp;
    public GameObject winMenu;
    public GameObject loseMenu;
    private bool otherMenu;
    private Scene currentScene;


    // Start is called before the first frame update
    void Start()
    {
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
        SceneManager.LoadScene("Menu");
    }
    public void GoToNextLevel()
    {
        if (currentScene.buildIndex < (SceneManager.sceneCountInBuildSettings -1))
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        else
        {
            ReturnToMenu();
        }
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    
    public void DisablePlayers()
    {
        GameObject.FindGameObjectWithTag("Human").GetComponent<PlayerMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("Cat").GetComponent<PlayerMovement>().enabled = false;
    }

}
