using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player physics
    private Rigidbody playerRb;
    public float gravityModifier = 1;

    // Player movement variables
    public float speed = 20;
    public float jumpForce = 80;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    // Player movement method
    void PlayerMovement()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Horizontal movement
        if (Input.GetKey(KeyCode.D) && !gameOver)
        {
            playerRb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.A) && !gameOver)
        {
            playerRb.AddForce(Vector3.left * speed);
        }
    }

    // Collision logic == Player can only jump if colliding with a platform
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = false;
        }
    }

    // When Player collides with Powerup, powerup the player and destroy Powerup game object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Powerup obtained");
            Destroy(other.gameObject);
        }
        // When player collides with ground, game ends
        if (other.gameObject.CompareTag("Ground"))
        {
            gameOver = true;
        }
    }
}