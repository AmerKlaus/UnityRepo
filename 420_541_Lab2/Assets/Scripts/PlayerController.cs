using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void FixedUpdate() // Physics-related operations should go here
    {
        // Get input for horizontal and vertical axes
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the player's forward and right vectors
        Vector3 movement = (transform.right * moveX) + (transform.forward * moveZ);

        // Apply movement to the rigidbody
        // Apply movement to the rigidbody
        rb.AddForce(movement * moveSpeed, ForceMode.Force);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You Win");
        }
        else if (other.CompareTag("DeathPlane"))
        {
            rb.position = startPosition;
        }
    }
}
