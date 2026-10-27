using UnityEngine;

public class Fireball : MonoBehaviour
{
    public PlayerMovement playerMovement; 
    private GameObject player;
    private Rigidbody2D rb;

    public float force;
    public int damage;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");


        if (player.transform)
        {
            rb.linearVelocity = new Vector2(-50f, transform.position.y).normalized * force;
        }
        else
        {
            rb.linearVelocity = new Vector2(50f, transform.position.y).normalized * force;
        }
        //Vector3 direction = player.transform.position - transform.position;
        

        //float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
            Destroy(gameObject);
        }*/
        //Destroy(gameObject);
    }
}
