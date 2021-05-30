using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryDialogLevelOne_2 : MonoBehaviour
{
    public GameObject dialogWrapper;
    public GameObject dialogBox;
    public GameObject boardingPass;
    private int timeToWin = 33;
    private int curIndex = 0;
    private bool gameOver = false;

    public static string[] sentences = { "Congratulations! You have successfully protected yourself from the MITM enemy. However, this is not the end. There are other dangers which include malware injection and WiFi sniffing.",
        "Malware injection refers to the situation when malware leak into your computer when you are on an insecure network. It can steal your bandwidth and damage your system. WiFi sniffing is when third paties can monitor and log your data packets when you are on an insecure network.",
        "Use a VPN to protect yourself from these dangers. VPN helps by sending your traffic through an encrypted tunnel, which makes it hard to intercept data.",
        "Now, you are ready to use the public WiFi with VPN to retrieve your electronic copy of your booking itinerary!",
        "To celebrate your flight to London, you decided to share your boarding pass on social media. ",
        "However, this is highly not recommended as sensitive information is on your boarding pass! The barcode on your boarding pass can easily contain data that you hackers can use to access your account with the airline. Bon Voyage!"
         };

    void Update()
    {
        if (Time.timeSinceLevelLoad > timeToWin && !gameOver)
        {
            gameOver = true;
            dialogWrapper.SetActive(true);
            StartCoroutine(TypeSentence(sentences[curIndex]));

            curIndex++;
        }
        
    }

    public void DisplayNextSentence()
    {
        if (curIndex == sentences.Length)
        {
            // Load Next Scene
            SceneManager.LoadScene(22);
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentences[curIndex]));

            if (curIndex == sentences.Length - 2)
            {
                boardingPass.SetActive(true);
            } else
            {
                boardingPass.SetActive(false);
            }

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
