using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static int conduitCount = 0; //counter for conduits collected, accessable by other scripts
    public GameObject levelCanvas; //set a canvas gameobject in the inspector
    public static bool missionComplete = false; //mission complete bool accessable by other scripts
    public Text playerHealthText; //set player health text in the inspector
    public static int repairsDone = 0; //counter for how many conduits have been repaired, accessable by other scripts
    public GameObject pausePanel; //set a pause panel gameobject in the inspector
    public CharControlPlayer charControlPlayer; //access charControlPlayer script
    public PlayerHealth playerHealth; //access PlayerHealth script
    

    // Start is called before the first frame update
    void Start()
    {
        playerHealth.health = 100; // set player health to 100
        Cursor.visible = false;  //turn cursor off
        playerHealthText.text = "Health " + playerHealth.health.ToString(); //set the player health text to "Health " + the health value in the PlayerControl script set to a string
        pausePanel.SetActive(false); //pause panel game object is set ti inactive
        
        conduitCount = 0; //sets conduit count to 0 when game starts
        charControlPlayer.hasWeapon = false; //set hasWeapon bool to false when game starts
    }

    // Update is called once per frame
    void Update()
    {
        //if the conduit count is greater than or = to 0
        if (conduitCount >= 0)
        {
            //set the levelCanvas text to "Power Conduits " + the cureent conduit count int set to a string
            levelCanvas.GetComponent<Text>().text = "Power Conduits " + conduitCount.ToString();
            //if the escape key is pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //make cursor visible
                Cursor.visible = true;
                //activate the pause panel
                pausePanel.SetActive(true);
                //set the time scale to 0
                Time.timeScale = 0;
            }
        }


        //update players health the the current health int in the PlayerControl script
        playerHealthText.text = "Health " + playerHealth.health.ToString();

        //if the repairsDone int = 3
        if (repairsDone == 3)
        {
            //set missionComplete bool to true
            missionComplete = true;
        }
    }

    //clicking the ResumeButton on the pause panel will deactivate the pausel panel and set the time scale back to 1
        public void ResumeButton()
        {
            Cursor.visible = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

    //clicking the quit button on the pause panel will close the application
        public void QuitGame()
    {
        Application.Quit();
    }
    
}
