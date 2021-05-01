using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Access Modifier, Data Type, Name
    private float speed = 35.0f;
    private float turnSpeed = 80.0f;
    private float zBound = 60;
    public float xRange = 60;
    private float hInput;
    private float fInput;

    


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    // Prevents the player from leaving the top, bottom, left and right of the map
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);  // Made constraints on the edge of map barrier on z axis the top of the map
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);  // Made constraints on the edge of map barrier on the z axis bottom of the map
        }


        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); // Made constraints on the edge of map barrier on x axis
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z); // Made constraints on the edge of map barrier on x axis
        }

        //Moves the player based on arrow key input
        {
            hInput = Input.GetAxis("Horizontal");  //Gathers the inputs for the controls
            fInput = Input.GetAxis("Vertical");   //Gathers the inputs for the controls

            transform.Translate(Vector3.forward * Time.deltaTime * speed * fInput);  // Makes the Player go forward and back

        } transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime); // Makes the Player go left and right
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // if the player collieded with player
        {
            Debug.Log("Player has collided with enemy."); // message will display if player collieded with enemy
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup")) //  powerup trigger
        {
            Destroy(other.gameObject); // Destroys powerup object when player collides with powerup
        }
    }
}
