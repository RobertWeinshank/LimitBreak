using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //[SerializeField] Floating_Healthbar floatingHealthBar;
    public EnemyMovement enemyMovement;
    private Rigidbody2D rb;
    private Transform currentPoint;

    public float currentHealth;
    public float maxHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //floatingHealthBar = GetComponentInChildren<Floating_Healthbar>();
    }

    void Start()
    {
        //floatingHealthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        //floatingHealthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (amount < 0 && currentHealth > 0)
        {
            //enemyMovement.enemyHit();
        }

        if (currentHealth <= 0)
        {
           enemyMovement.enemyKilled();
        }
    }
}
