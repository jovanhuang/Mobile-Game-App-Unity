using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// ColumnOne class is responsible for bringing player to level one of the game
public class ColumnOne : MonoBehaviour
{
    /// @param xPos parameter to save the player vector just before transition to level one
    private float xPos;

    /// OnCollisionEnter2D function invokes if player enters column in game, saves the players vector and transits player to level one
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            xPos = GameObject.FindGameObjectWithTag("Player").transform.position.x; // get player current position
            PlayerPrefs.SetFloat("SavedXPosition", xPos); // save player current position
            SceneManager.LoadScene("Level1_1.1"); // goes to level 1
        }
    }
}