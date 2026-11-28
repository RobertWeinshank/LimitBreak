using Microsoft.Extensions.Logging.Abstractions;
using System.Collections;
using System.Reflection.PortableExecutable;
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

    public GameObject healthPotion;
    public GameObject limitPotion;
    public Transform potionSpawnPoint;

    public Animator doorAnimation;

    private int dropAmount = 1;

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
            if (dropPotion() != null)
            {
                Instantiate(dropPotion(), potionSpawnPoint.position, Quaternion.identity);
            }
            
            //dropPotion();
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

    private GameObject dropPotion()
    {
        float randomDrop;
        if (dropAmount < 0)
        {
            return null;           
        }
        else
        {
            randomDrop = Random.value * 100;
            if (randomDrop > 50)
            {
                Debug.Log(randomDrop + "Health");
                dropAmount--;
                return healthPotion;
            }
            else
            {
                Debug.Log(randomDrop + "Limit");
                dropAmount--;
                return limitPotion;
            }
        }
    }


    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(fadeTime);
        player.position = newPlayerPosition;
        SceneManager.LoadScene(sceneToLoad);
    }
}
