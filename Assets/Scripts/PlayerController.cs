using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 5f; // Speed of the player
    public float speedX, speedY;
    public static PlayerController Instance;
    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    private Vector2 movementInput;

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * playerSpeed; // Get horizontal input and multiply by player speed
        speedY = Input.GetAxis("Vertical") * playerSpeed; // Get vertical input and multiply by player speed
        rb.linearVelocity = new Vector2(speedX, speedY); // Set the velocity of the Rigidbody2D based on input

        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");

        movementInput = movementInput.normalized;

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Speed", movementInput.magnitude);
    }
}
