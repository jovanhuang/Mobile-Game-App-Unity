using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// ColumnFour class is responsible for bringing player to level four of the game
public class ColumnFour : MonoBehaviour
{
    /// @param xPos parameter to save the player vector just before transition to level four
    private float xPos;

    /// OnCollisionEnter2D function invokes if player enters column in game, saves the players vector and transits player to level four
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            xPos = GameObject.FindGameObjectWithTag("Player").transform.position.x; // get player current position
            PlayerPrefs.SetFloat("SavedXPosition", xPos); // save player current position 
            SceneManager.LoadScene("Lvl4_MG1_Scene1"); // load level 4
        }
        
    }
}
