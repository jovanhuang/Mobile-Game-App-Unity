using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// This script represents the Intro dialog used in the WiFi catching game.
public class StartDialog : MonoBehaviour
{
    /// Game object representing the dialog box.
    public GameObject dialogBox;
    /// Game object representing the continue button.
    public GameObject continueButton;
    /// Audio that is played in the background when the Dialog is shown.
    public AudioSource BackgroundAudio;
    /// Audio that is played whenver the Continue button is pressed.
    public AudioSource nextAudio;
    private int curIndex = 0;

    /// Array representing the pieces of text that are shown in the dialog.
    public static string[] sentences = { "You are at Changi Airport, trying to catch a flight to London. You only have an electronic copy of your booking itinerary and you need to retrieve it from your email inbox to get your air ticket at the counter. You have no mobile data and would have to make use of the public WiFis available.",
        "However, not all public WiFis can be trusted. There are a few public WiFis that are established by the Singapore government.",
        "In this game, your task is to catch all the trusted WiFis. Avoid the fake WiFis at all cost!",
         };

    void Start()
    {
        BackgroundAudio.Play();
        StartCoroutine(TypeSentence(sentences[curIndex]));

        curIndex++;
    }

    /// Function is called when Continue button is pressed to display the next piece of text.
    public void DisplayNextSentence()
    {
        nextAudio.Play();

        if (curIndex == sentences.Length)
        {
            // Load Game Scene
            SceneManager.LoadScene("Level1_1.2");
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
