using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerConduit : MonoBehaviour
{
    public Text powerConduitText; //set a UI text component in the inspector

    //Awake is called when the script instance is being loaded
    private void Awake()
    {
        gameObject.SetActive(true);
    }

    //if the player enters the trigger
    //increment the conduit count int in the LevelController script and deactivate the power conduit game object
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            LevelController.conduitCount++;
            gameObject.SetActive(false);
        }
    }
}
