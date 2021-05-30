using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// This is the script for the main manager file for DScene.
/// 
/// Once triggered, it opens the interactive dialog box and loads the data in sequential form. Once the user has gone through the whole dialog, it transitions to the next scene.
public class DialogueManage : MonoBehaviour
{

public Text nameText;
public Text dialogueText;
public string moving="redundant";


public Animator danimator;
public Animator tanimator;

private Queue<string> sentences;


    /// Start is called before the first frame update
    void Start()
    {
     sentences = new Queue<string>();
    }

    /// StartDialogue is called once the dialogue is triggered. It takes in all the dialogue sentences and enqueues them, ready for display.
    /// 
    /// @param dsentence contains the dialogue sentences.
public void StartDialogue(DSentence dsentence){

danimator.SetBool("Open", true);
     tanimator.SetTrigger("Close");

    
    nameText.text = dsentence.name;

    sentences.Clear();

    foreach(string sentence in dsentence.sentences){
        sentences.Enqueue(sentence);
    }
    DisplayNextSentence();
}

/// DisplayNextSentence displays the next sentence in the dialogue once the user interacts with the continue button.
public void DisplayNextSentence(){

    if(sentences.Count==0){
        EndDialogue();
        return;

    }
    string sentence= sentences.Dequeue();
    StopAllCoroutines();
    StartCoroutine(TypeSentence(sentence));
}

/// For Coroutine
/// 
/// @param sentence contains one dialogue sentence.
IEnumerator TypeSentence(string sentence){
    dialogueText.text = "";

    foreach(char letter in sentence.ToCharArray()){
        dialogueText.text += letter;
        yield return null;
    }
}

/// EndDialogue ends the dialogue once user finishes engagin with the dialog box. It also paves the way for the next scene.
void EndDialogue(){
danimator.SetBool("Open", false);
OpenNew();


}
/// Responsible for transitioning to the next scene with the help of LLoader.
void OpenNew(){
    
        FindObjectOfType<LLoader>().BeginNextScene(moving);
    
}
   
}
