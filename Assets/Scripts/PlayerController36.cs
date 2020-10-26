using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController36 : MonoBehaviour
{
    float moveSpeed = 10.0f;
    float vLimit = 7.0f;
    float jumpForce = 10.0f;
    float spaceTrack = 0.0f;

    float gravityModifier = 2.5f;

    Rigidbody playerRb;

    bool isGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Code
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * moveSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * moveSpeed);

        //Front and Back Boundary
        if (transform.position.z < -vLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -vLimit);
        }

        else if (transform.position.z > vLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, vLimit);
        }

        //Left and Right Boundary
        if (transform.position.x < -vLimit)
        {
            transform.position = new Vector3(-vLimit, transform.position.y, transform.position.z);
        }

        else if (transform.position.x > vLimit)
        {
            transform.position = new Vector3(vLimit, transform.position.y, transform.position.z);
        }

        //JumpPlayer();
        //DoubleJump();
        DoubleSpaceJump();
    }

    //Collision Code with the ground object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;

            spaceTrack = 0;
        }
    }

    //Jump Method / Single Jump Code
    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            spaceTrack++;
            Debug.Log(spaceTrack);
        }
    }

    //Jump Method / Double Jump Code
    private void DoubleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spaceTrack == 2)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            spaceTrack++;
            Debug.Log(spaceTrack);
        }
    }

    //Jump Method / Checking for space key twice before jumping
    private void DoubleSpaceJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceTrack++;

            if (spaceTrack == 2)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
