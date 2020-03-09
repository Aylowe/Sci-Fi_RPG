using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public CharControlPlayer charControlPlayer; //access charControlPlayer script
    public GameObject laserHolder; //object for holding laser projectile
    
    
    //if player enters the trigger, set the hasWeapon bool in the PlayerControl script to true. Destroy weapon game object
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            charControlPlayer.hasWeapon = true;
            laserHolder.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
