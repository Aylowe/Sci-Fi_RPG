using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject laserEffect; //laser game object
    public CharControlPlayer charControlPlayer; //access charControlPlayer script

    [SerializeField][Range(.1f, 2)] //show in inspector with a slide bar ranging from 0.1 - 2
    private float fireRate = .5f; //rate of fire


    // Start is called before the first frame update
    void Start()
    {
        laserEffect.SetActive(true);
    }

    //Update is called once per frame
    private void Update()
    {
        FireWeapon();
    }

    //Shoot the weapon
    void FireWeapon()
    {
        if (charControlPlayer.hasWeapon == true)
        {
            while (Input.GetKey(KeyCode.Mouse0))
            {
                StartCoroutine(ShootLaser());
                break;
            }  
        }
    }

    //instantiate laser object
    IEnumerator ShootLaser()
    {
        Instantiate(laserEffect, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(fireRate);
    }
}
