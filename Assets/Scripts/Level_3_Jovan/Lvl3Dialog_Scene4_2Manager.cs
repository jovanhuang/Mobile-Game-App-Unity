  using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// This class is used to manage the Scene 4.2 transition.
/// 
/// It shows the storyline on the speech text bubble.
public class Lvl3Dialog_Scene4_2Manager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI hostDialogueText;

    [SerializeField] private string[] hostDialogueSentences;

    [SerializeField] private GameObject choiceOneButton;

    [SerializeField] private GameObject choiceTwoButton;

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
    /// Activate Choice 1 and Choice 2 buttons.
    public void ContinueHostDialogue()
    {
        if (hostIndex < hostDialogueSentences.Length - 1)
        {
            hostIndex++;
            StartCoroutine(hostDialogue());
        }
        else
        {
            choiceOneButton.SetActive(true);
            choiceTwoButton.SetActive(true);
        }
    }

    /// This method will load the scene meant for choice 1.
    /// 
    /// Load Scene 5.1 of Level 3.
    public void goChoiceOneDialogue()
    {
          SceneManager.LoadScene("Lvl3_Dialog_Scene5.1");
    }

    /// This method will check load the scene meant for choice 2.
    /// 
    /// Load Scene 5.1 of Level 3.
    public void goChoiceTwoDialogue()
    {
        SceneManager.LoadScene("Lvl3_Dialog_Scene5.2");
    }

}