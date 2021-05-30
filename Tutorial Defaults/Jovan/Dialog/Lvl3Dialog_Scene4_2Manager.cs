  using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Lvl3Dialog_Scene4_2Manager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI hostDialogueText;

    [SerializeField] private string[] hostDialogueSentences;

    [SerializeField] private GameObject choiceOneButton;

    [SerializeField] private GameObject choiceTwoButton;

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
            choiceOneButton.SetActive(true);
            choiceTwoButton.SetActive(true);
        }
    }

    public void goChoiceOneDialogue()
    {
          SceneManager.LoadScene("Lvl3_Dialog_Scene5.1");
    }

    public void goChoiceTwoDialogue()
    {
        SceneManager.LoadScene("Lvl3_Dialog_Scene5.2");
    }

}