using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public PlayerHealth playerHealth;
    private Rigidbody2D rb;

    public float speed = 10.0f;

    //public int facingDirection = 1;
    public bool lookingLeft = false;
    private Vector2 input;

    private bool isKnockedBack; //leave thsi in incase you want to have a knockback system that pushes the player back-- i can take this out if i don't (definitely not necessary)

    public GameObject magic;
    public Transform lookDirection;

    private int fireballDamage = 1;

    public float timer = 2;

    Vector2 shootPosition;
    Vector2 futurePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        shootPosition = lookDirection.transform.position;
        futurePosition = new Vector2(transform.position.x + 20, transform.position.y);

        if (!isKnockedBack)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            input.Normalize(); //makes diagonal movement speed the same as all other speeds; without it diagonal speed moves faster
            

            timer += Time.deltaTime;
            if (Input.GetMouseButtonDown(0))
            {
                if (timer > .25)
                {
                    timer = 0;
                    //shoot();
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isAttacking", true);
                    playerHealth.ChangeLimit(fireballDamage);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            rb.linearVelocity = input * speed;

            if (input.x != 0 || input.y != 0)
            {
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalking", true);

                if (input.x > 0)
                {
                    //GetComponent<SpriteRenderer>().flipX = false;
                    transform.localScale = new Vector3(1, 1, 1);
                    lookingLeft = false;
                }
                else if (input.x < 0)
                {
                    //GetComponent<SpriteRenderer>().flipX = true;
                    transform.localScale = new Vector3(-1, 1, 1);
                    lookingLeft = true;
                }
            }
            else if (rb.linearVelocity.x == 0 && rb.linearVelocity.y == 0)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", true);
            }
        }
    }


    public void shoot()
    {
        GameObject fireball = Instantiate(magic, shootPosition, Quaternion.identity);
        Vector2 shootDirection = (futurePosition - shootPosition).normalized;
        
        if (lookingLeft)
        {
            fireball.GetComponent<Fireball>().Setup(-shootDirection, 10f);
        }
        else
        {
            fireball.GetComponent<Fireball>().Setup(shootDirection, 10f);
        }
        
    }

    public void endShoot()
    {
        animator.SetBool("isAttacking", false);
    }
}
