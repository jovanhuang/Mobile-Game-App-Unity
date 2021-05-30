using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Lvl3Dialog_TryAgainBirdGame : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI hostDialogueText;

    [SerializeField] private string[] hostDialogueSentences;

    [SerializeField] private GameObject TryAgainButton;
    [SerializeField] private GameObject SkipButton;

    private int hostIndex;

    private void Start()
    {
        StartCoroutine(hostDialogue());
    }
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

    public void TryAgainButtonManager()
    {
        SceneManager.LoadScene("Lvl3_MG1_B");
    }

    public void SkipButtonManager()
    {
        SceneManager.LoadScene("Lvl3_Dialog_Scene4.1");
    }



}