using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    [Header("Referencias")]
    public Transform enemy;
    public Transform player;
    public BoxCollider2D patrolArea;

    [Header("Velocidades")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;

    [Header("Distancias")]
    public float reachThreshold = 0.1f;
    public float chaseRange = 5f;

    private Vector2 patrolTarget;
    private bool isChasing = false;

    private GameManager gamemanager;

    void Start()
    {
        
        PickNewPatrolPoint();
    }

    void Update()
    {
        if (enemy == null || player == null) return;

        float distanceToPlayer = Vector2.Distance(enemy.position, player.position);
        bool playerInsideArea = patrolArea.bounds.Contains(player.position);

        if (distanceToPlayer <= chaseRange && playerInsideArea)
        {
            isChasing = true;
        }
        else if (isChasing && (!playerInsideArea || distanceToPlayer > chaseRange + 1f))
        {
            isChasing = false;
            PickNewPatrolPoint();
        }

        if (isChasing)
            ChasePlayer();
        else
            Patrol();
    }

    private void Patrol()
    {
        Vector2 direction = patrolTarget - (Vector2)enemy.position;
        if (direction.magnitude < reachThreshold)
        {
            PickNewPatrolPoint();
            return;
        }

        enemy.position = Vector2.MoveTowards(enemy.position, patrolTarget, patrolSpeed * Time.deltaTime);
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.position - enemy.position).normalized;
        enemy.position = Vector2.MoveTowards(enemy.position, player.position, chaseSpeed * Time.deltaTime);
    }

    private void PickNewPatrolPoint()
    {
        Bounds b = patrolArea.bounds;
        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);
        patrolTarget = new Vector2(x, y);
    }

    private void OnDrawGizmosSelected()
    {
        if (patrolArea != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(patrolArea.bounds.center, patrolArea.bounds.size);
            Gizmos.DrawSphere(patrolTarget, 0.1f);
        }

        if (enemy != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(enemy.position, chaseRange);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {  
            
        }
    }
}