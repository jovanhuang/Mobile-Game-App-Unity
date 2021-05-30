using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartDialog : MonoBehaviour
{
    public GameObject dialogBox;
    private int curIndex = 0;

    public static string[] sentences = { "You are at Changi Airport, trying to catch a flight to London. You only have an electronic copy of your booking itinerary and you need to retrieve it from your email inbox to get your air ticket at the counter. You have no mobile data and would have to make use of the public WiFis available.",
        "However, not all public WiFis can be trusted. There are a few public WiFis that are established by the Singapore government.",
        "In this game, your task is to catch all the trusted WiFis. Avoid the fake WiFis at all cost!",
         };

    void Start()
    {
        StartCoroutine(TypeSentence(sentences[curIndex]));

        curIndex++;
    }

    public void DisplayNextSentence()
    {
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
        Text dialogText = dialogBox.GetComponent<Text>();
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }
}
