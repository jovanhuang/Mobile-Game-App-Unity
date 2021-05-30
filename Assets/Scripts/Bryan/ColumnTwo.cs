using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// ColumnTwo class is responsible for bringing player to level two of the game
public class ColumnTwo : MonoBehaviour
{
    /// @param xPos parameter to save the player vector just before transition to level two
    private float xPos;

    /// OnCollisionEnter2D function invokes if player enters column in game, saves the players vector and transits player to level two
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            xPos = GameObject.FindGameObjectWithTag("Player").transform.position.x; // get player current position
            PlayerPrefs.SetFloat("SavedXPosition", xPos); // save player current location
            SceneManager.LoadScene("DScene"); // goes to level 2
        }
    }
}
