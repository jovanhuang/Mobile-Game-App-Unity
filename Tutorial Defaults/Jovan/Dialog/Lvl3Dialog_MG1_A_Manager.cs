using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Lvl3Dialog_MG1_A_Manager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI hostDialogueText;

    [SerializeField] private string[] hostDialogueSentences;

    [SerializeField] private GameObject readyButton;

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
        yield return new WaitForSeconds(1/2);
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
            readyButton.SetActive(true);
        }
    }

    public void enterMG1()
    {
        SceneManager.LoadScene("Lvl3_MG1_B");
    }


}