using UnityEngine;

public class BossMain : MonoBehaviour
{
    public BossHead bossHead;
    public BossBody bossBody;
    public BossShoulder bossShoulder;
    public BossLArm bossLArm;
    public BossRArm bossRArm;

    public GameObject leftAttackZone;
    public GameObject rightAttackZone;

    public bool rightAttack = false;
    public bool leftAttack = false;

    public bool headDestroyed = false;
    public bool bodyDestroyed = false;
    public bool shoulderDestroyed = false;
    public bool larmDestroyed = false;
    public bool rarmDestroyed = false;

    public float rAttackTimer;
    public float lAttackTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rAttackTimer += Time.deltaTime;
        lAttackTimer += Time.deltaTime;

        if (leftAttack) 
        {
            //set animation to true; in animation call a damage window that displays zone of whats being damaged (red circle sprite) then turn animation off on final frame
            //enter timer
            if (lAttackTimer > 2)
            {
                Debug.Log("left penis");
                bossLArm.animator.SetBool("isAttacking", true);
                lAttackTimer = 0;
            }  
        }

        if (rightAttack)
        {
            //set animation to true; in animation call a damage window that displays zone of whats being damaged (red circle sprite) then turn animation off on final frame
            //enter timer
            if (rAttackTimer > 2)
            {
                Debug.Log("right penis");
                bossRArm.animator.SetBool("isAttacking", true);
                rAttackTimer = 0;
            }
        }

        if (headDestroyed)
        {
            bossHead.animator.SetBool("isDestroyed", true);
            bossHead.circleCollider.enabled = false;
        }
        if (bodyDestroyed)
        {
            bossBody.animator.SetBool("isDestroyed", true);
            bossBody.edgeCollider.enabled = false;
        }
        if (shoulderDestroyed)
        {
            bossShoulder.animator.SetBool("isDestroyed", true);
            bossShoulder.edgeCollider.enabled = false;
        }
        if (larmDestroyed)
        {
            bossLArm.animator.SetBool("isDestroyed", true);
            bossLArm.transform.position = new Vector3(-55.25f, 50.7f, 0);
            bossLArm.capsuleCollider.enabled = false;
        }
        if (rarmDestroyed)
        {
            bossRArm.animator.SetBool("isDestroyed", true);
            bossRArm.transform.position = new Vector3(-43.85f, 50.7f, 0);
            bossRArm.capsuleCollider.enabled = false;
        }
    } 
}
