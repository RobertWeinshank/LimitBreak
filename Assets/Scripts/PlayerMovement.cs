using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private Animator animator;
    private Rigidbody2D rb;

    public float speed = 10.0f;

    //public int facingDirection = 1;
    public bool lookingLeft = false;
    private Vector2 input;

    private bool isKnockedBack; //leave thsi in incase you want to have a knockback system that pushes the player back-- i can take this out if i don't (definitely not necessary)

    public GameObject magic;
    public Transform magicPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnockedBack)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            input.Normalize(); //makes diagonal movement speed the same as all other speeds; without it diagonal speed moves faster

            if (Input.GetMouseButtonDown(0))
            {
                shoot();   
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
                //animator.SetBool("isRunning", true);
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
        }
    }


    public void shoot()
    {
        Instantiate(magic, magicPos.position, Quaternion.identity);
    }
}
