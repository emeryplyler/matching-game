using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // physics stuff
    public Rigidbody2D rb;
    public float moveSpeed; // max player movement speed
    float movementX; // desired directions to move
    float movementY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // called when player tries to move, based on input map
    void OnMove(InputValue moveValue)
    {
        Vector2 moveVec = moveValue.Get<Vector2>();
        movementX = moveVec.x; // store in variables for greater scope
        movementY = moveVec.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // handle movement
        Vector2 movement = new Vector2(movementX, movementY);
        rb.AddForce(movement * moveSpeed);
    }
}
