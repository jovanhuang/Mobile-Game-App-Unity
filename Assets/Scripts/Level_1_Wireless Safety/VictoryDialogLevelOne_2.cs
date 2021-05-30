using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// This script is responsible for the Victory Dialog for the spaceship shooting game.
public class VictoryDialogLevelOne_2 : MonoBehaviour
{
    /// Game object representing the continue button.
    public GameObject continueButton;
    /// Audio that is palyed whe
    public AudioSource NextAudio;
    /// Game object representing the dialog wrapper.
    public GameObject dialogWrapper;
    /// Game object representing the dialog bx.
    public GameObject dialogBox;
    /// Game object representing the boarding pass.
    public GameObject boardingPass;
    private int timeToWin = 33;
    private int curIndex = 0;
    private bool gameOver = false;

    /// Array representing the pieces of text that are displayed in the dialog.
    public static string[] sentences = { "Congratulations! You have successfully protected yourself from the MITM enemy. However, this is not the end. There are other dangers which include malware injection and WiFi sniffing.",
        "Malware injection refers to the situation when malware leak into your computer when you are on an insecure network. It can steal your bandwidth and damage your system. WiFi sniffing is when third parties can monitor and log your data packets when you are on an insecure network.",
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

    /// Function is called to display the next piece of sentence when the button Continue is pressed.
    public void DisplayNextSentence()
    {
        NextAudio.Play();

        if (curIndex == sentences.Length)
        {
            // Load Next Scene
            SceneManager.LoadScene("Game");
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
