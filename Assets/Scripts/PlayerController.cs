using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 5f;
    public float speedX, speedY;

    private bool moviendose;

    public bool dragActive;

    private Vector2 lastDirection;

    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private Vector2 movementInput;
    private Vector2 lastMovementInput;


void Update()
{
 
    Vector2 rawInput = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")
    );

    
    movementInput = rawInput.normalized;
    speedX = movementInput.x * playerSpeed;
    speedY = movementInput.y * playerSpeed;
    rb.linearVelocity = new Vector2(speedX, speedY);

   
    bool isMoving = movementInput.magnitude > 0.01f;
    moviendose = isMoving;

    
    if (isMoving)
    {
        lastMovementInput = movementInput; 
    }

   
    animator.SetFloat("Horizontal", movementInput.x);
    animator.SetFloat("Vertical", movementInput.y);
    animator.SetFloat("Speed", movementInput.magnitude);
    animator.SetBool("Moviendose", moviendose);

  
    animator.SetFloat("LastHorizontal", lastMovementInput.x);
    animator.SetFloat("LastVertical", lastMovementInput.y);
}
    
}
