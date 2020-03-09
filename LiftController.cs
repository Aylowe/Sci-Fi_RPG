using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftController : MonoBehaviour
{

    public GameObject text; //set a text game object in the inspector
    Animator anim; //animator component

    bool liftUp = true; //is lift at the top
    bool liftcanmove = false; //cam the lift move

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>(); //get the animator component on the game object
    }

    // Update is called once per frame
    void Update()
    {
        //call the move lift function
        MoveLift();
    }

    //if the player enters the trigger
    //activate the text game object
    //set the liftcanmove bool to true
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            liftcanmove = true;            
        }
    }

    //if the player leaves the trigger
    //deactivate text
    //call LiftIdle function
    //set liftcanmove bool to false
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            LiftIdle();
            liftcanmove = false;
        }
    }

    //if space is pressed, play the lift move animations
    private void MoveLift()
    {
        if (liftUp == true && liftcanmove == true)

        {
            anim.SetBool("AtBottom", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space bar pressed");
                anim.SetBool("GoingDown", true);
                
            }
        }
         else if(liftUp == false && liftcanmove == true)
         {
            anim.SetBool("AtTop", false);
            Debug.Log("Lift can go up");
            if(Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("GoingUp", true);
                
            }
         }
    }

    //switch to lift idle animations
    void LiftIdle()
    {
            if (liftUp == true)
            {
                anim.SetBool("AtBottom", true);
                liftUp = false;
                anim.SetBool("GoingDown", false);
            }
            else
            {
                anim.SetBool("AtTop", true);
                liftUp = true;
                 liftcanmove = false;
            anim.SetBool("GoingUp", false);
            }
    }
}
