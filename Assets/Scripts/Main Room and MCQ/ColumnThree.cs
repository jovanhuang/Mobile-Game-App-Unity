using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// ColumnThree class is responsible for bringing player to level three of the game
public class ColumnThree : MonoBehaviour
{
    /// @param xPos parameter to save the player vector just before transition to level three
    private float xPos;

    /// OnCollisionEnter2D function invokes if player enters column in game, saves the players vector and transits player to level three
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            xPos = GameObject.FindGameObjectWithTag("Player").transform.position.x; // get player current position
            PlayerPrefs.SetFloat("SavedXPosition", xPos); // save player current position
            SceneManager.LoadScene("Lvl3_Dialog_Scene1"); // load level 3
        }
    }
}
