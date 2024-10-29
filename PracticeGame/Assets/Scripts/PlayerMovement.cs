using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    private Rigidbody rb;
    public Vector3 planeMinBounds; // Min x and y of the plane
    public Vector3 planeMaxBounds; // Max x and y of the plane

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * walkSpeed * Time.deltaTime;
        transform.position += movement;

        // Clamp Johny's position within the plane bounds
        float clampedX = Mathf.Clamp(transform.position.x, planeMinBounds.x, planeMaxBounds.x);
        float clampedZ = Mathf.Clamp(transform.position.z, planeMinBounds.z, planeMaxBounds.z);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}
