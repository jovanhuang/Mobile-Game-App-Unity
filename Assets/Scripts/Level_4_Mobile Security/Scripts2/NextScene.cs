using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

/// This script is responsible for transitioning to the MCQ scene.
public class NextScene : MonoBehaviour {
    /// Upon pressing the button, scene is transitioned.
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(nextScenePlease);
    }

    /// Transitions to the MCQ scene.
    public void nextScenePlease()
    {
        SceneManager.LoadScene("Game");
    }

}