using UnityEngine;

public class BossLArm : MonoBehaviour
{
    public BossMain bossMain;

    public Animator animator;
    public CapsuleCollider2D capsuleCollider;

    public int maxHealth;
    public int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            bossMain.larmDestroyed = true;
        }
    }
    public void ChangeHealth(int amount)
    {
        if (currentHealth > 0 && amount < 0)
        {
            currentHealth += amount;

            if (amount < 0 && currentHealth > 0)
            {
                //playerMovement.playerHit();
            }
            else if (amount < 0 && currentHealth <= 0)
            {
                //RemovePlayer();
                //RespawnPlayer();
            }
        }
        else if (amount > 0)
        {
            currentHealth += amount;
        }
    }
    public void stopLeftAttack()
    {
        animator.SetBool("isAttacking", false);
    }
}
