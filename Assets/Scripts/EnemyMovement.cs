using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform detectionPoint;
    public LayerMask playerLayer;
    
    public float speed;
    public float playerDetectRange = 2;
    public float attackCooldown = 2;
    public float attackRange = 0.2f;

    private float attackCooldownTimer;
    private int facingDirection = -1;

    private Animator animator;
    private Rigidbody2D rb;
    private Transform player;

    public bool inChase = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        CheckForPlayer();

        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        if (inChase)
        {
            Chase();
        }

        //sets velocity to 0 when attacking; dont need to have this, kinda like the enemies being able to move while shooting at the player
        //else if (enemyState == EnemyState.Attacking)
        //{
        //    rb.linearVelocity = Vector2.zero;
        //}
    }

    void Chase()
    {
        if (player.position.x > transform.position.x && facingDirection == -1 ||
            player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;


            if (Vector2.Distance(transform.position, player.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                if (player.position.x > transform.position.x && facingDirection == -1 || player.position.x < transform.position.x && facingDirection == 1)
                {
                    Flip();
                }
                //ChangeState(EnemyState.Attacking);
            }

            else if (Vector2.Distance(transform.position, player.position) >= attackRange)
            {
                //ChangeState(EnemyState.Chasing);
                inChase = true;
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            //ChangeState(EnemyState.Idle);
            inChase = false;
        }
    }

    public void enemyKilled()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}
