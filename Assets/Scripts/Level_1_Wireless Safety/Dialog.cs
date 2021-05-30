using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// This script is responsible for the Intro dialog in the spaceship shooting scene.
public class Dialog : MonoBehaviour
{
    /// Game object representing the continue button.
    public GameObject continueButton;
    /// Audio that is played in the background during the dialog.
    public AudioSource BackgroundAudio;
    /// Audio that is played when user presses on Contninue.
    public AudioSource nextAudio;
    /// Game object representing the dialog box.
    public GameObject dialogBox;
    private int curIndex = 0;

    /// Array containing the lines to be displayed to the user in the dialog.
    public static string[] sentences = { "Despite being on trusted public WiFis, you could be potentially exposing yourself to dangers where hackers can access sensitive data on your device.",
        "An imminent danger is MITM (Man In The Middle). The hackers position their devices between the connection with your device and WiFI spot, allowing them to monitor your activity and intercept sensitive data like banking details.",
        "MITMs have been on a spree lately and wants to attack you. Your job is to survive the MITM onslaught. Move the spaceship using the joysticsk and tap on the right half of the screen to shoot. You can use VPN shield power-ups to protect yourself.", 
         };

    void Start()
    {
        BackgroundAudio.Play();
        StartCoroutine(TypeSentence(sentences[curIndex]));

        curIndex++;
    }

    /// Function that is called to display next piece of text in the dialog on pressing Continue.
    public void DisplayNextSentence()
    {
        nextAudio.Play();

        if (curIndex == sentences.Length)
        {
            // Load Game Scene
            SceneManager.LoadScene("Level1_2.2");
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentences[curIndex]));

            curIndex++;
        }


    }

    IEnumerator TypeSentence(string sentence)
    {
        continueButton.SetActive(false);
        Text dialogText = dialogBox.GetComponent<Text>();
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
        continueButton.SetActive(true);

    }
}
