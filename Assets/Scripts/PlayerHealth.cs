using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    public int currentHealth;
    public int maxHealth;

    public int currentLimit;
    public int maxLimit;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ChangeHealth(int amount)
    {
        if (currentHealth > 0 && amount < 0)
        {
            currentHealth += amount;
            //HealthText.text = "HP: " + currentHealth + " / " + maxHealth;

            if (amount < 0 && currentHealth > 0)
            {
                //playerMovement.playerHit();
            }
            else if (amount < 0 && currentHealth <= 0)
            {
                //playerMovement.playerDied();
                RemovePlayer();
            }
        }
        else if (amount > 0)
        {
            currentHealth += amount;
            //HealthText.text = "HP: " + currentHealth + " / " + maxHealth;
        }
    }

    public void ChangeLimit(int amount)
    {
        currentLimit += amount;

        if(currentLimit == maxLimit)
        {
            RemovePlayer();
        }
    }

    public void RemovePlayer()
    {
        Destroy(gameObject);
    }
}
