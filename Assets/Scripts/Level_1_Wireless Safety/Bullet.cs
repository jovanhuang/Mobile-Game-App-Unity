using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// This script models the Bullet for the ship character.
public class Bullet : MonoBehaviour
{
    /// Audio that is played when a bullet successfully collides with the enemy.
    public AudioSource KillAudio;
    /// Set default speed of bullet to be 50.
    public float speed = 50.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private static int killCount = 0;

    /// Game object for explosion that will be instantiated on collision between bullet and enemy.
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenBounds.x * -2)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") // If collide with enemy, render explosion, then destory asteroid and gameobject
        {
            GameObject e = Instantiate(explosion) as GameObject;
            // KillAudio.Play();
            e.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);

            killCount++;
            Debug.Log(killCount);

            if (killCount == 3)
            {
                StopAllCoroutines();
                Debug.Log("hi");
            }
        }
    }
}