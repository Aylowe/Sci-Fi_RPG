using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerLaser : MonoBehaviour
{
    public GameObject parent; //parent gameobject

    //Awake is called when the script instance is being loaded
    private void Awake()
    {
        parent.SetActive(true);
    }

    //Start is called before the first frame update
    private void Start()
    {
        parent.SetActive(true);
    }

    //If laser particle hits an enemy or environment, destroy after 2 seconds
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Untagged" || other.gameObject.tag == "Enemy")
        {
            Invoke("DestroyLaserHolder", 2);
        }
    }

    //Destroy parent gameobject
    void DestroyLaserHolder()
    {
        Destroy(parent);
    }
}

