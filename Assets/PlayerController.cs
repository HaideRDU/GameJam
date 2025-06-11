using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 5f; // Speed of the player
    public float speedX, speedY; // Speed in X and Y directions

    Rigidbody2D rb; // Rigidbody component for physics interactions
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
    }

    // Update is called once per frame
    void Update()
    {
           speedX = Input.GetAxis("Horizontal") * playerSpeed; // Get horizontal input and multiply by player speed
              speedY = Input.GetAxis("Vertical") * playerSpeed; // Get vertical input and multiply by player speed
        rb.linearVelocity = new Vector2(speedX, speedY); // Set the velocity of the Rigidbody2D based on input
    }
}
