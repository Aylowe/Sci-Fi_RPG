using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; //make cursor visible
    }

    //Load the level scene
    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
    }

    //Close the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
