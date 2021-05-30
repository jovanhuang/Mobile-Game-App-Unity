using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// This script is responsible for the logic of collisions of Bullet and Powerups.
public class CollideShip : MonoBehaviour
{
    /// Audio that is played when the game is played.
    public AudioSource BackgroundAudio;
    /// Audio that is played when a powerup shield is attained.
    public AudioSource ShieldAudio;
    /// Audio that is played when the ship collides with an enemy.
    public AudioSource DieAudio;
    /// Audio that is played when a bullet collides with an enemy.
    public AudioSource KillAudio;
    /// Game object representing the ship.
    public GameObject spaceship;
    /// Game object representing the shield powerup.
    public GameObject shield;
    /// Game object representing the explosion.
    public GameObject explosion;
    /// Game object representing the animation that is played on powerup.
    public GameObject powerupAnim;
    private bool hasShield = false;

    /// Game object representing the dialog for restarting the gaem.
    public GameObject dialogWrapper;
    public GameObject dialogBox;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundAudio.Play();
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
            ShieldAudio.Play();
            p.transform.position = transform.position;

            Destroy(other.gameObject);

            //Shield last for 7 seconds
            StartCoroutine(endShield());

        }


        if (other.tag == "Enemy" && !hasShield) // If collide with enemy, restart game
        {
            // Show restart dialog
            DieAudio.Play();
            dialogWrapper.SetActive(true);
        }
        else if  (other.tag == "Enemy" && hasShield)
        {
            GameObject e = Instantiate(explosion) as GameObject;
            KillAudio.Play();
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

    /// This function is called to restart the game whenever the ship collides with the enemy.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
