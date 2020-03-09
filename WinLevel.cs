using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; //make cursor visible
    }

    //click the main menu button to load the main menu scene
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    //click the quit button to close the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
