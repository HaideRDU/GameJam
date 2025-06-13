using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 5f; // Speed of the player
    public float speedX, speedY;

    private bool moviendose;

    public bool dragActive;

    private Vector2 lastDirection;

    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    private Vector2 movementInput;
    private Vector2 lastMovementInput;

    // Update is called once per frame

void Update()
{
    // 1. Lee el input RAW (sin normalizar) para el movimiento físico...
    Vector2 rawInput = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")
    );

    // 2. Normaliza para mover al player y calcula velocidad
    movementInput = rawInput.normalized;
    speedX = movementInput.x * playerSpeed;
    speedY = movementInput.y * playerSpeed;
    rb.linearVelocity = new Vector2(speedX, speedY);

    // 3. ¿Se está moviendo?
    bool isMoving = movementInput.magnitude > 0.01f;
    moviendose = isMoving;

    // 4. SOLO si realmente hay movimiento, actualiza última dirección NORMALIZADA
    if (isMoving)
    {
        lastMovementInput = movementInput; 
    }

    // 5. Actualiza siempre los parámetros de animación
    animator.SetFloat("Horizontal", movementInput.x);
    animator.SetFloat("Vertical", movementInput.y);
    animator.SetFloat("Speed", movementInput.magnitude);
    animator.SetBool("Moviendose", moviendose);

    // 6. Y usa ese lastMovementInput (normalizado) para el Idle
    animator.SetFloat("LastHorizontal", lastMovementInput.x);
    animator.SetFloat("LastVertical", lastMovementInput.y);
}
    
}
