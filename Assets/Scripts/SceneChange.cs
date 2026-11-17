using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject doorBarrier;
    
    public string sceneToLoad;
    public Animator fadeAnim;
    public float fadeTime = .5f;
    public Vector2 newPlayerPosition;
    private Transform player;

    public GameObject[] enemies;

    public Animator doorAnimation;

    private void Start()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        winScreen.SetActive(false);
    }

    private void Update()
    {
        if (AllEnemiesDefeated())
        {
            doorAnimation.SetBool("isOpened", true);
            doorBarrier.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (AllEnemiesDefeated())
        {
            if (collision.gameObject.tag == "Player")
            {
                player = collision.transform;
                //fadeAnim.Play("FadeToWhite");
                //StartCoroutine(DelayFade());
                winScreen.SetActive(true);
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
