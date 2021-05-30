using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// The script is in charge of the controller logic of handling the lives in the WiFi Catching game.
public class LivesController : MonoBehaviour
{
    /// Count of lives for the game.
    public static int livesCount;
    public GameObject Live1;
    public GameObject Live2;
    public GameObject Live3;
    public GameObject RestartMenu;


    void Start()
    {
        livesCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (livesCount == 2)
        {
            Live3.SetActive(false);
        }

        if (livesCount == 1)
        {
            Live2.SetActive(false);
        }

        if (livesCount == 0)
        {
            // Game Over
            Live1.SetActive(false);

            RestartMenu.SetActive(true);
        }
    }

    /// Function is called whenever the lives count fall to zero to restart the game.
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1_1.2");
    }
}
