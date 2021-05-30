using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class nextScene : MonoBehaviour {

    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(nextScenePlease);
    }

    public void nextScenePlease()
    {
        //to change and insert next scene
        SceneManager.LoadScene("Game");
    }

}