using UnityEngine;

public class Limit_Potion : MonoBehaviour
{
    public int limitRestore = 3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeLimit(-limitRestore);
            Destroy(gameObject);
        }
    }
}
