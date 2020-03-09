using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float health = 10f; //Enemies health, accessable by other scripts
    private bool canSeePlayer = false; //is the player in range
    private bool canShoot = false; //can the enemy shoot
    public GameObject target; //set a target GameObject in the inspector
    public float speed = 1.5f; //Enemies move speed
    Animator anim; //Animator component
    NavMeshAgent enemyNavMesh; //Nav mesh component
    public GameObject projectile; //Set projectile GameObect in the inspector
    public GameObject firePoint; //set a spawn point for projectiles in the inspector
    public GameObject[] waypoints; //array of waypoint game objects
    SphereCollider trigger; //collider for player detection
    int currentWaypoint = 0; //current waypoint in the array
    float accuracy = 1f; //how close enemy needs to get to waypoints
    private WaitForSeconds shotDuration = new WaitForSeconds(2);//time to wait after shot is fired
    private float nextFire = 0; //when enemy will shoot again
    private float fireRate = .5f; //rate of fire
    public float currentHealth; //enemies current health
    public bool hasBeenHit = false; //has the enemy been hit
    RagdollContoller ragdollController; //ragdoll component
    Rigidbody rigidBody; //rigidbody component


    //Awake is called when the script instance is being loaded
    private void Awake()
    {
        health = 5; //set enemy health to 5
        
       
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        enemyNavMesh = gameObject.GetComponent<NavMeshAgent>();
        trigger = gameObject.GetComponentInChildren<SphereCollider>();
        ragdollController = GetComponent<RagdollContoller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(canSeePlayer == true) //if the enemy can see the player
        {
            EnemyMove(); //call EnemyMove function
            FireWeapon();//call FireWeapon function
        }
       else if (canSeePlayer == false)
        {
            EnemyPatrol(); //call enemy patrol function
        }
        
         EnemyDeath(); //call enemy Death function
    }

    //move enemy towards target and play walk animation
    void EnemyMove()
    {
        enemyNavMesh.SetDestination(target.transform.position);
        anim.SetBool("IsWalking", true);
    
    }

    //spawn projectile at the firepoint location and rotation
    void FireWeapon()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());
        }
    }

    //if player enters the trigger, set canSeePlayer and canShoot bools to true
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canSeePlayer = true;
            canShoot = true;
        }
    }

    //if player exits the trigger, set canSeePlayer and canShoot bools to false
    //stop walking animation
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canSeePlayer = false;
            canShoot = false;
            anim.SetBool("IsWalking", false);
        }
    }


   //if enemy health is less than or equal to 0, destroy enemy
   void EnemyDeath()
    {
        if(currentHealth <= 0)
        {
            ragdollController.RagdollOn(true);
            enemyNavMesh.enabled = false;
            rigidBody.AddForce(-Vector3.forward, ForceMode.Impulse);
        }
    }

    //enemy patrol around waypoints in array
    void EnemyPatrol()
    {
        if (waypoints.Length == 0) return;

        enemyNavMesh.SetDestination(waypoints[currentWaypoint].transform.position);
        if (enemyNavMesh.speed > 0)
        {
            anim.SetBool("IsWalking", true);
        }
        Vector3 direction = waypoints[currentWaypoint].transform.position - this.transform.position;

        if (direction.magnitude < accuracy)
        {
            StartCoroutine(WaypointWaitTime());
            
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }

    //time to wait at waypoint before moving on
    IEnumerator WaypointWaitTime()
    {
        anim.SetBool("IsWalking", false);
        yield return new WaitForSeconds(Random.Range(1, 5));
        int waypointRandomiser = Random.Range(0, 7);
        currentWaypoint = waypointRandomiser;
    }

    //instantiate enemy projectile
    private IEnumerator ShotEffect()
    {
        Vector3 pos = new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, firePoint.transform.position.z);
        Quaternion rot = firePoint.transform.rotation;

        Instantiate(projectile, pos, rot);
        yield return shotDuration;
    }
    
    //decrease health if hit by player projectile
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            currentHealth--;
        }
    }
}
