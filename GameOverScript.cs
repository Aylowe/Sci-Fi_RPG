using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; //make cursor visible
    }

    //Load the main menu scene
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    //Quit the application
    public void QuitButton()
    {
        Application.Quit();
    }
}
