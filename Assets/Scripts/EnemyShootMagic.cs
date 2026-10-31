using UnityEngine;

public class EnemyShootMagic : MonoBehaviour
{
    public GameObject magic;
    public Transform magicPos;

    private float timer;

    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }
        //Debug.Log(distance);
    }

    public void shoot()
    {
        Instantiate(magic, magicPos.position, Quaternion.identity);
    }
}
