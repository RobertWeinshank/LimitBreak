using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage;
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerLayer;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player ontop of enemy");
        }
    }

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
            Debug.Log("Player hit");
        }
    }


}
