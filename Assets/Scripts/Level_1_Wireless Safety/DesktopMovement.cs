using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This script is used for debugging purposes on the desktop to move the ship using the keyboard.
public class DesktopMovement : MonoBehaviour
{
    ///  This represents the ship.
    public Transform player;
    /// This is the speed of the spaceship.
    public float speed = 5.0f;
    /// This is the game object representing the prefab of the Bullet.
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        if (Input.GetKeyDown("space")) // Use spacebar to shoot
        {
            shootBullet();
        }
    }

    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }

    /// This function is called whenever the user wants to shoot a bullet.
    public void shootBullet()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;
    }
}