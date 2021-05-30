using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// This class is used to manage the Scene 3.1 transition.
/// 
/// It shows the storyline on the speech text bubble.
public class Lvl3Dialog_Scene3_1Manager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI hostDialogueText;

    [SerializeField] private string[] hostDialogueSentences;

    [SerializeField] private GameObject hostContinueButton;


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
    /// It will activate the continue button.
    private IEnumerator hostDialogue()
    {
        foreach (char letter in hostDialogueSentences[hostIndex].ToCharArray())
        {
            hostDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        hostContinueButton.SetActive(true);
    }

    /// This method will check if text has been fully loaded.
    /// 
    /// Call HostDialogue() again if it has not been fully loaded.
    /// Load Scene 2 of Level 3 after it has been fully loaded.
    public void ContinueHostDialogue()
    {
        if (hostIndex < hostDialogueSentences.Length - 1)
        {
            hostContinueButton.SetActive(false);
            hostIndex++;
            hostDialogueText.text = string.Empty;
            StartCoroutine(hostDialogue());
        }
        else
        {
            SceneManager.LoadScene("Lvl3_Dialog_Scene2");
        }
    }

    /// This method will enter the Mini Game.
    /// 
    /// Load Mini Game scene.
    public void enterGame()
    {
        SceneManager.LoadScene("Lvl3_MG1");
    }


}