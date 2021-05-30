using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// This class is used to manage the transition flow of Level 3 MiniGame's Instruction scene.
/// 
/// It manages the typing speed of the speech bubble text and handles actions like clicking on the "I am ready button"
public class Lvl3Dialog_MG1_A_Manager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI hostDialogueText;

    [SerializeField] private string[] hostDialogueSentences;

    [SerializeField] private GameObject readyButton;

    private int hostIndex;

    /// This method is called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// 
    /// It will call StartCoroutine on the hostDialogue() method.
    private void Start()
    {
        StartCoroutine(hostDialogue());
    }

    /// This method loads the text word by word.
    /// 
    /// It will call ContinueHostDialogue() to check if it has finished loading the text.
    private IEnumerator hostDialogue()
    {
        foreach (char letter in hostDialogueSentences[hostIndex].ToCharArray())
        {
            hostDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(1/2);
        hostDialogueText.text += "\n";
        ContinueHostDialogue();

    }

    /// This method will check if text has been fully loaded.
    /// 
    /// Set Ready button to true for user to click on it.
    public void ContinueHostDialogue()
    {
        if (hostIndex < hostDialogueSentences.Length - 1)
        {
            hostIndex++;
            StartCoroutine(hostDialogue());
        }
        else
        {
            readyButton.SetActive(true);
        }
    }

    /// This method will load a new scene, which is the enter mini-game.
    /// 
    /// Load Lvl3_MG1_B scene
    public void enterMG1()
    {
        SceneManager.LoadScene("Lvl3_MG1_B");
    }


}