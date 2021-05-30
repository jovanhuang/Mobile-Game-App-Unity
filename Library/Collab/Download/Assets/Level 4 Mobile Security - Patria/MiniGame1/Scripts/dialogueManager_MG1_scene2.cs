using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
///hello
///
/// hello2
public class dialogueManager_MG1_scene2 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI hostDialogueText;

    [SerializeField] private string[] hostDialogueSentences;

    [SerializeField] private GameObject hostContinueButton;

    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject Monster;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;
    [SerializeField] private GameObject Jump;

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

        hostContinueButton.SetActive(true);
        
    }

    public void ContinueHostDialogue()
    {
        if (hostIndex < hostDialogueSentences.Length - 1){
            hostContinueButton.SetActive(false);
            hostIndex++;
            hostDialogueText.text = string.Empty;
            StartCoroutine(hostDialogue());
            Left.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
        }
        else{
            Canvas.SetActive(false);
            Monster.gameObject.SetActive(false);
            Left.gameObject.SetActive(true);
            Right.gameObject.SetActive(true);
            Jump.gameObject.SetActive(true);

        }
    }
}
