using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneToLoad;
    public Animator fadeAnim;
    public float fadeTime = .5f;
    public Vector2 newPlayerPosition;
    private Transform player;

    public GameObject[] enemies;

    private void Start()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (AllEnemiesDefeated())
        {
            if (collision.gameObject.tag == "Player")
            {
                player = collision.transform;
                fadeAnim.Play("FadeToWhite");
                StartCoroutine(DelayFade());
            }
        }
    }
    bool AllEnemiesDefeated()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(fadeTime);
        player.position = newPlayerPosition;
        SceneManager.LoadScene(sceneToLoad);
    }
}
