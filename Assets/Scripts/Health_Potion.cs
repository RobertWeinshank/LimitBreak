using UnityEngine;

public class Health_Potion : MonoBehaviour
{
    public int healthRestore = 3;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(healthRestore);
            Destroy(gameObject);
        }
    }
}
