using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// Buttons class to manage the "Menu" scene buttons
public class Buttons : MonoBehaviour
{
    /// @param startGameButton manages the "Start Game" Button
    public Button startGameButton;

    /// @param exitButton manages the "Exit" Button
    public Button exitButton;

    /// NewGame function loads "Introduction" Scene when "Start Game" button is pressed
    public void NewGame() {
        SceneManager.LoadScene("Introduction");
    }

    /// ExitGame function quits application when exit button is pressed
    public void ExitGame() {
        Application.Quit();
    }
}
