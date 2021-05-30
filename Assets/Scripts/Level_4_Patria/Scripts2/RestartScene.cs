using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
/// This script is responsible for restarting the game.
public class RestartScene : MonoBehaviour {
    /// Upon pressing the button, scene is transitioned.
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(RestartGame);
    }
    /// Restarts MiniGame2 of Level 4.
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}