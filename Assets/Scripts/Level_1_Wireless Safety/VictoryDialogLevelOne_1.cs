using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// This script is responsible for the Victory Dialog for the Wifi Catching game.
public class VictoryDialogLevelOne_1 : MonoBehaviour
{
    /// Game object representing the continue button.
    public GameObject continueButton;
    /// Audo that is played in the background.
    public AudioSource BackgroundAudio;
    /// Audio that is played when Continue button is pressed.
    public AudioSource NextAudio;
    /// Game object representing the dialog box.
    public GameObject dialogBox;
    private int curIndex = 0;

    /// Array representing the pieces of text that are displayed on the dialog.
    public static string[] sentences = { "Congratulatons! You have successfully identified the trusted WiFis.",
        "If you know you are going to somewhere without a mobile data connection and you need to use the internet, remember to do research beforehand on what are the trusted WiFis of a public place! Trusted WiFis in Singapore include Wireless@SG and WiFi@Changi.",
        "Now, you are ready to select a WiFi to retrieve your booking itinerary!",
         };

    void Start()
    {
        BackgroundAudio.Play();
        StartCoroutine(TypeSentence(sentences[curIndex]));

        curIndex++;
    }

    /// Function that is called to display the next piece of text when Continue button is pressed.
    public void DisplayNextSentence()
    {
        NextAudio.Play();

        if (curIndex == sentences.Length)
        {
            // Load Game Scene
            SceneManager.LoadScene("Level1_2.1");
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
