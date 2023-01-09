using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{


    // Direction from the Zombie to the Player
    Vector3 direction;

    Transform playerTransform;

    Rigidbody rb;

    Animator animator;


    HealthManager playerHealthManager;
    bool dealDamage;
    [SerializeField] float damage;

    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Look for the Player in the scene
        playerTransform = GameObject.Find("Player").transform;



        playerHealthManager = playerTransform.GetComponent<HealthManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            dealDamage = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
            dealDamage = false;
    }

    // Update is called once per frame
    void Update()
    {   
        //if there is no player don't move
        if (!playerTransform)
        {
            direction= Vector3.zero;
            return;
        }
        //Calculate the direction from the zombie to the player
        direction=playerTransform.position-transform.position;

        //make sure the zombie only follows on the xy plane
        direction.y = 0;

        //rotate the zombiz 
        rb.rotation= Quaternion.LookRotation(direction);

        //make sure it doesn't spin when hetting objects
        rb.angularVelocity = Vector3.zero;

        //move the zombie 
        rb.MovePosition(rb.position+direction.normalized*speed*Time.deltaTime);

        //animate the zombie
        animator.SetFloat("MoveSpeed", 1);


        // Take damage over time.
        if (dealDamage && playerHealthManager)
            playerHealthManager.TakeDamage(damage * Time.deltaTime);
    }
}
