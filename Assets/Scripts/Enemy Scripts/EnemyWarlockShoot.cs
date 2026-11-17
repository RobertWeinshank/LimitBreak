using UnityEngine;

public class EnemyWarlockShoot : MonoBehaviour
{
    public EnemyMovement enemyMovement;

    public GameObject magic;
    public Transform magicPos;

    private float timer;
    private float shootTimer;

    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null && enemyMovement.inChase)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            for (int i = 0; i < 3; i++)
            {
                shootTimer += Time.deltaTime;
                if (shootTimer > .5)
                {
                    shootTimer = 0;
                    //shoot();

                }
            }
        }
        //Debug.Log(distance);
    }

    public void shoot()
    {
        Instantiate(magic, magicPos.position, Quaternion.identity);
    }
}
