using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Button startGameButton;
    public Button exitButton;
    public Button musicButton;
    public Button soundButton;

    public void NewGame() {
        SceneManager.LoadScene(0);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
