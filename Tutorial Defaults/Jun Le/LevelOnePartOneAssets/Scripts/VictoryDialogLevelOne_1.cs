using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryDialogLevelOne_1 : MonoBehaviour
{
    public GameObject dialogBox;
    private int curIndex = 0;

    public static string[] sentences = { "Congratulatons! You have successfully identified the trusted WiFis.",
        "If you know you are going to somewhere without a mobile data connection and you need to use the internet, remember to do research beforehand on what are the trusted WiFis of a public place! Trusted WiFis in Singapore include Wireless@SG and WiFi@Changi.",
        "Now, you are ready to select a WiFi to retreieve your booking itinerary!",
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
        Text dialogText = dialogBox.GetComponent<Text>();
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }
}
