using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorsController : MonoBehaviour
{

    public Animator anim; //amimator component

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>(); //get the animator component on the game object
    }

    
    //if player, friendly or enemy enter the trigger, open the door
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Friendly" || other.gameObject.tag == "Enemy")
        {
            Debug.Log("Detected " + other.tag as string);
            anim.SetBool("Open", true);
            anim.SetBool("Closed", false);
        }
    }

    //if player, friendly or enemy exit the trigger, close the door
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Friendly" || other.gameObject.tag == "Enemy")
        {
            anim.SetBool("Closed", true);
            anim.SetBool("Open", false);
        }  
    }
}
