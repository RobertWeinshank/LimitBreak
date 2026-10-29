using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 pointA = new Vector3(8, 4, 0);
    Vector3 pointB = new Vector3(8, -4, 0);

    void Update()
    {
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time * 0.5f, 1));
    }

    public void enemyKilled()
    {
        Destroy(gameObject);
    }
}
