using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockInnerDoor : MonoBehaviour
{
    Animator anim; //animator component

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>(); //get gameObjects animator component
    }

    
    //if player, friendly or enemy tags enter the trigger and if LevelController's mission complete bool is true
    //play open animation
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Friendly" || other.gameObject.tag == "Enemy")
        {
            if (LevelController.missionComplete == true)
            {
                anim.SetBool("Open", true);
                anim.SetBool("Closed", false);
            }
        }
    }

    //if player, friendly or enemy exit the colider
    //play closed animation
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Friendly" || other.gameObject.tag == "Enemy")
        {
            anim.SetBool("Closed", true);
            anim.SetBool("Open", false);
        }
    }
}
