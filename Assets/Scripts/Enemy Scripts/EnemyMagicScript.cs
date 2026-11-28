using UnityEngine;

public class EnemyMagicScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    public float force;
    public int damage;
    public bool rotateFireball = false;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        if (rotateFireball)
        {
            float rot = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }
        else
        {
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3.5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
            collision.gameObject.GetComponent<PlayerHealth>().ChangeLimit(1);
            Destroy(gameObject);
        }
    }
}
