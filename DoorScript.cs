using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator topAnim; //animator component
    Animator bottomAnim; //animator component
    public GameObject topDoor; //set a topDoor game object in the inspector
    public GameObject bottomDoor; //set a bottom door game object in the inspector
    

    // Start is called before the first frame update
    void Start()
    {
        topAnim = topDoor.GetComponent<Animator>(); //set topAnim to the animator component on the topDoor game object
        bottomAnim = bottomDoor.GetComponent<Animator>(); //set bottomAnim to the animator componenet on the bottomDoor game object
    }

   
    //if player, friendly or enemy enter the trigger, open the door
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Friendly" || other.gameObject.tag == "Enemy")
        {
            topAnim.SetBool("Open", true);
            bottomAnim.SetBool("Open", true);
            topAnim.SetBool("Closed", false);
            bottomAnim.SetBool("Closed", false);
            Debug.Log("TopTrigger");
        }
    }

    //if player, friendly or enemy exit the trigger, close the door
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Friendly" || other.gameObject.tag == "Enemy")
        {
            topAnim.SetBool("Closed", true);
            bottomAnim.SetBool("Closed", true);
            topAnim.SetBool("Open", false);
            bottomAnim.SetBool("Open", false);
            Debug.Log("Bottom Trigger");
        }
    }
}
