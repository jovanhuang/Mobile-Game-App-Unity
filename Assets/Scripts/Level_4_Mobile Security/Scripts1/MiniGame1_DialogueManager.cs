using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// This script is responsible for managing the Pop-up dialogues when the player interacts with the monster sprites.
public class MiniGame1_DialogueManager : MonoBehaviour
{
    /// Set speed which letters appear
    protected float typingSpeed = 0.01f;
    [SerializeField] private TextMeshProUGUI hostDialogueText;
    [SerializeField] private string[] hostDialogueSentences;
    [SerializeField] private GameObject hostContinueButton;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject Monster;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;
    [SerializeField] private GameObject Jump;
    [SerializeField] private GameObject Thief;
    [SerializeField] private GameObject CongratsCanvas;
    private int hostIndex;
    private string[] monsterList;
    private int randomIndex;
    private GameObjectInitialisation gameObjectInitialisation;

    private void Start()
    {
        StartCoroutine(hostDialogue());
        CongratsCanvas.SetActive(false);
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
    ///Function is called when 'Continue' Button is pressed.
    public void ContinueHostDialogue()
    {
        if (hostIndex < hostDialogueSentences.Length - 1){
            hostContinueButton.SetActive(false);
            hostIndex++;
            hostDialogueText.text = string.Empty;
            StartCoroutine(hostDialogue());
        }
        else{
            Canvas.SetActive(false);
            Monster.gameObject.SetActive(false);
            Left.gameObject.SetActive(true);
            Right.gameObject.SetActive(true);
            Jump.gameObject.SetActive(true);

            // appearance of thief
            GameObjectInitialisation goi = GameObject.Find("Player").GetComponent<GameObjectInitialisation>();
            monsterList = goi.getMonsterList();
            randomIndex = goi.getRandomIndex();
            Debug.Log(randomIndex);
            if (Monster.gameObject.name==monsterList[randomIndex]){
                Debug.Log("thief appears");
                Thief.SetActive(true);
                CongratsCanvas.SetActive(true);
            }
            // Transition to next scene
            if (Monster.gameObject.name=="Thief"){
                SceneManager.LoadScene("Lvl4_MG2_Scene1");
            }

        }
    }
}
