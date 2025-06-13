using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 1.4f;
    Transform target;

    private void Awake()
    {
     
            rb = GetComponent<Rigidbody2D>();
        }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag

    }
        
        
   
    void FixedUpdate()
    {
        if (target)
        {

            // Calculate direction to player
            Vector3 direction = (target.position - transform.position).normalized;

        // Move towards the player
        rb.linearVelocity = new Vector2 (direction.x, direction.y) * moveSpeed;
    }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
                GameManager.Instance.GameOver();
        }
    }
}
