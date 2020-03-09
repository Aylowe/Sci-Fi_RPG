using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharControlPlayer : MonoBehaviour
{
    CharacterController myController; //character controller component
    Animator playerUnarmedAnim; //animator component

    private bool isCrouched = false; //is player crouched bool. initialised to false

    [SerializeField][Range(0,500)]//show in inspector with a slide bar ranging from 0 - 500
    private float runSpeed = 50; //running speed
    [SerializeField][Range(0, 100)]//show in inspector with a slide bar ranging from 0 - 100
    private float crouchWalkSpeed = 10; //speed walking while crouched

    private Vector3 moveDirection = Vector3.zero; //player move direction

    

    public bool hasWeapon = false; //bool for does the player have a weapon

    public float weaponRange = 50f; //range of weapon
    public float hitForce = 100f; //force of weapon impact
    public float gravity = 20; //gravity

    public GameObject firePoint; //gameobject for where projectile will spawn
    public GameObject weapon; //weapon game object
    

    private Camera cam; //camera


    //Awake is called when the script instance is being loaded
    private void Awake()
    {
        hasWeapon = false; 
    }


    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        playerUnarmedAnim = gameObject.GetComponent<Animator>();
        cam = GetComponentInChildren<Camera>();
        hasWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        moveDirection.y -= gravity;
        
        PlayerMove(x, y);
    }

    //Function to move the player depending on whether the player has a weapon or is crouched
    void PlayerMove(float x, float y)
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        if(hasWeapon == true)
        {
            playerUnarmedAnim.SetBool("hasWeapon", true);
            weapon.SetActive(true);
        }
        else
        {
            playerUnarmedAnim.SetBool("hasWeapon", false);
        }
        

        if (isCrouched == false)
        {
                Vector3 localDirection = new Vector3(transform.right.x * xMovement,
                                                    Physics.gravity.y, 
                                                    transform.forward.z * zMovement) * runSpeed * Time.deltaTime;

               
                myController.SimpleMove(transform.forward * Input.GetAxis("Vertical") * runSpeed * Time.deltaTime);
                myController.SimpleMove(transform.right * Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime);
                

                playerUnarmedAnim.SetFloat("VelX ", x);
                playerUnarmedAnim.SetFloat("VelY", y);
        }

        if (isCrouched == true)
        {
            myController.SimpleMove(new Vector3(xMovement, Physics.gravity.y, zMovement) * crouchWalkSpeed * Time.deltaTime);

            playerUnarmedAnim.SetFloat("VelX ", x);
            playerUnarmedAnim.SetFloat("VelY", y);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouched == false)
            {
                isCrouched = true;
                playerUnarmedAnim.SetBool("isCrouching", true);
            }
            else if (isCrouched == true)
            {
                isCrouched = false;
                playerUnarmedAnim.SetBool("isCrouching", false);
            }
        }
    }
}




