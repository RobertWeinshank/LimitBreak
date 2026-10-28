using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool lookingLeft = false;

    public int damage;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    
    public void Setup(Vector2 direction, float force)
    {
        rb = GetComponent<Rigidbody2D>();
        if (lookingLeft)
        {
            rb.AddForce(-direction * force, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        //if (collision.TryGetComponent(out Target target))
        //{
        //    //target.Damage();
        //    Destroy(gameObject);
        //}
    }
}
