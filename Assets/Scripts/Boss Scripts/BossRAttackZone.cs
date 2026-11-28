using UnityEngine;

public class BossRAttackZone : MonoBehaviour
{
    public BossMain bossMain;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
            bossMain.rightAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
            bossMain.rightAttack = false;
        }
    }
}
