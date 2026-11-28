using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    public int currentHealth;
    public int maxHealth;

    public int currentLimit;
    public int maxLimit;

    public TMP_Text HealthText;
    public TMP_Text LimitText;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthText.text = "HP: " + currentHealth + " / " + maxHealth;
        LimitText.text = "Limit Point: " + currentLimit + " / " + maxLimit;            
    }

    private void Update()
    {
        if (currentLimit > 0)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                ChangeLimit(-1);
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        if (currentHealth > 0 && amount < 0)
        {
            currentHealth += amount;
            HealthText.text = "HP: " + currentHealth + " / " + maxHealth;

            if (amount < 0 && currentHealth > 0)
            {
                //playerMovement.playerHit();
            }
            else if (amount < 0 && currentHealth <= 0)
            {
                //playerMovement.playerDied();
                RemovePlayer();
                RespawnPlayer();
            }
        }
        else if (amount > 0)
        {
            currentHealth += amount;
            HealthText.text = "HP: " + currentHealth + " / " + maxHealth;
        }
    }

    public void ChangeLimit(int amount)
    {
        currentLimit += amount;
        LimitText.text = "Limit Point: " + currentLimit + " / " + maxLimit;

        if (currentLimit == maxLimit)
        {
            RemovePlayer();
            RespawnPlayer();
        }
    }

    public void RemovePlayer()
    {
        Destroy(gameObject);
    }

    public void RespawnPlayer()
    {
        //fadeAnim.Play("FadeToWhite");
        //StartCoroutine(DelayFade());
        SceneManager.LoadScene("SampleScene");
        //StartCoroutine(DelayFade());
        ChangeHealth(maxHealth);
        ChangeLimit(maxLimit);
    }
}
