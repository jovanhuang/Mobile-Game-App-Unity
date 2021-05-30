using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideShip : MonoBehaviour
{
    public GameObject spaceship;
    public GameObject shield;
    public GameObject explosion;
    public GameObject powerupAnim;
    private bool hasShield = false;

    public GameObject dialogWrapper;
    public GameObject dialogBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasShield)
        {
            shield.transform.position = spaceship.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Powerup")
        {
            hasShield = true;
            shield.SetActive(true);
            shield.transform.position = spaceship.transform.position;

            GameObject p = Instantiate(powerupAnim) as GameObject;
            p.transform.position = transform.position;

            Destroy(other.gameObject);

            //Shield last for 7 seconds
            StartCoroutine(endShield());

        }


        if (other.tag == "Enemy" && !hasShield) // If collide with enemy, restart game
        {
            // Show restart dialog
            dialogWrapper.SetActive(true);
        }
        else if  (other.tag == "Enemy" && hasShield)
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(other.gameObject);
        }
    }

    IEnumerator endShield()
    {
        yield return new WaitForSeconds(7.0f);
        hasShield = false;
        shield.SetActive(false);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
