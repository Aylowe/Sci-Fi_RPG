using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedPowerConduit : MonoBehaviour
{
    public Light interiorLight; //set a light in the inspector
    Color green = Color.green; //create a green colour on the RGB scale
    
    //if the player enters the trigger and the conduit count int in the LevelController script is greater than 0
    //change the interiorLight colour to green
    //increment the repairsDone int in the LevelController script
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && LevelController.conduitCount > 0)
        {
            interiorLight.color = green;
            LevelController.repairsDone++;
        }
    }
}
