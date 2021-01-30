using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //restart scene
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    /// <summary>
    /// OpenMenu should toggle the popup menu screen
    /// </summary>
    public void OpenMenu()
    {

    }

    public void PlayerDied()
    {
        //pop up dead menu
    }

    public void PlayerWin()
    {
        //pop up re-united menu
    }

    public void ReturnToMenu()
    {

    }
    public void GoToNextLevel()
    {

    }
    public void RetryLevel()
    {

    }
    

}
