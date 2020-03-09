using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinArea : MonoBehaviour
{
    //if the player enters the trigger and the missionComplete bool in the LevelController script is true, load the win scene
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && LevelController.missionComplete == true)
        {
            SceneManager.LoadScene(3);
        }
    }
}
