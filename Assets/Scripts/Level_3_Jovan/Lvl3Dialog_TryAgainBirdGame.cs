using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// This class is used to manage the Scene TryAgain transition.
/// 
/// It shows the Try Again message on the speech text bubble.
public class Lvl3Dialog_TryAgainBirdGame : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI hostDialogueText;

    [SerializeField] private string[] hostDialogueSentences;

    [SerializeField] private GameObject TryAgainButton;
    [SerializeField] private GameObject SkipButton;

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
        hostDialogueText.text += "\n";
        ContinueHostDialogue();
    }

    /// This method will check if text has been fully loaded.
    /// 
    /// Activate Try Again button and Skip button.
    public void ContinueHostDialogue()
    {
        if (hostIndex < hostDialogueSentences.Length - 1)
        {
            hostIndex++;
            StartCoroutine(hostDialogue());
        }   
        else
        {
            TryAgainButton.SetActive(true);
            SkipButton.SetActive(true);
        }
    }

    /// This method will load the scene meant for Try Again button.
    /// 
    /// Load MiniGame scene of Level 3.
    public void TryAgainButtonManager()
    {
        SceneManager.LoadScene("Lvl3_MG1_B");
    }

    /// This method will load the scene meant for Skip button.
    /// 
    /// Load Scene 4.1 of Level 3.
    public void SkipButtonManager()
    {
        SceneManager.LoadScene("Lvl3_Dialog_Scene4.1");
    }



}