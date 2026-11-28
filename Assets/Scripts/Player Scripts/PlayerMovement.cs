using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float meditateTimer = 1;

    public bool dashing = false;

    Vector2 shootPosition;
    Vector2 futurePosition;

    Vector2 mouseDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Debug.DrawLine(transform.position, mouseDirection);

        shootPosition = lookDirection.transform.position;
        futurePosition = new Vector2(transform.position.x + 20, transform.position.y);

        if (!isKnockedBack)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            input.Normalize(); //makes diagonal movement speed the same as all other speeds; without it diagonal speed moves faster
            

            timer += Time.deltaTime;
            meditateTimer += Time.deltaTime;
            if (!dashing)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (timer > .15)
                    {
                        timer = 0;
                        //shoot();
                        animator.SetBool("isDashing", false);
                        animator.SetBool("isWalking", false);
                        animator.SetBool("isIdle", false);
                        animator.SetBool("isCharging", false);
                        animator.SetBool("isAttacking", true);
                        //playerHealth.ChangeLimit(fireballDamage);
                    }
                }
            }
            //if (Input.GetMouseButtonDown(0))
            //{
            //    if (timer > .15)
            //    {
            //        timer = 0;
            //        //shoot();
            //        animator.SetBool("isDashing", false);
            //        animator.SetBool("isWalking", false);
            //        animator.SetBool("isIdle", false);
            //        animator.SetBool("isCharging", false);
            //        animator.SetBool("isAttacking", true);
            //        //playerHealth.ChangeLimit(fireballDamage);
            //    }
            //}
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //speed = 50;
                Debug.Log("penis");
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", false);
                animator.SetBool("isCharging", false);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isDashing", true);
            }


            if (Input.GetKey(KeyCode.E))
            {
                if (meditateTimer > 1)
                {
                    meditateTimer = 0;
                    if (playerHealth.currentLimit > 0)
                    {
                        animator.SetBool("isDashing", false);
                        animator.SetBool("isWalking", false);
                        animator.SetBool("isIdle", false);
                        animator.SetBool("isAttacking", false);
                        animator.SetBool("isCharging", true);
                        playerHealth.ChangeLimit(-1);
                    }
                    //Debug.Log("!");
                }
            }
            else
            {
                animator.SetBool("isCharging", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            rb.linearVelocity = input * speed;

            if (mouseDirection.x > input.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                //transform.localScale = new Vector3(1, 1, 1);
                lookingLeft = false;
            }
            else if (mouseDirection.x < input.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                //transform.localScale = new Vector3(-1, 1, 1);
                lookingLeft = true;
            }

            if (input.x != 0 || input.y != 0)
            {
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalking", true);

                //if (mouseDirection.x > input.x )
                //{
                //    GetComponent<SpriteRenderer>().flipX = false;
                //    //transform.localScale = new Vector3(1, 1, 1);
                //    lookingLeft = false;
                //}
                //else if (mouseDirection.x < input.x)
                //{
                //    GetComponent<SpriteRenderer>().flipX = true;
                //    //transform.localScale = new Vector3(-1, 1, 1);
                //    lookingLeft = true;
                //}
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
        Vector2 shootDirection = (mouseDirection).normalized;

        //fireball.GetComponent<Fireball>().Setup(shootDirection, 10f);

        if (lookingLeft)
        {
            fireball.GetComponent<Fireball>().Setup(-shootDirection, 10f);
        }
        else
        {
            fireball.GetComponent<Fireball>().Setup(-shootDirection, 10f);
        }

    }

    public void increaseSpeed()
    {
        speed = 15;
        dashing = true;
    }
    public void resetSpeed()
    {
        speed = 10;
        animator.SetBool("isDashing", false);
        dashing = false;
    }

    public void endShoot()
    {
        animator.SetBool("isAttacking", false);
    }
    public void endCharge()
    {
        animator.SetBool("isCharging", false);
    }
    public void playerDied()
    {
        animator.SetBool("isDead", true);
    }

    public void playerRespawn()
    {
        animator.SetBool("isDead", false);
        SceneManager.LoadScene("SampleScene");
    }
}
