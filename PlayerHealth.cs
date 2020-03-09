using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Range(0, 100)] //creates sliding bar in the inspector that ranges from 0 - 100
    public float health;

   

    // Start is called before the first frame update
    void Start()
    {
        health = 100; //set player health to 100 when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeath(); //call player death function
    }

    //deactivates player if health hits 0 and loads game over scene
    void PlayerDeath()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }
    }

    //decrease health when hit by enemy projectile particle
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "EnemyProjectile")
        {
            health--;
        }
    }
}
