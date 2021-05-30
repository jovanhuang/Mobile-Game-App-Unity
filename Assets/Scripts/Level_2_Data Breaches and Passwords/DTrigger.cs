using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This is the script for the dialogue trigger.
/// 
/// Once triggered, it starts the dialogue.
public class DTrigger : MonoBehaviour
{
   public DSentence dsentence;

/// It starts the dialogue on being triggered.
   public void TriggerDialogue(){
       FindObjectOfType<DialogueManage>().StartDialogue(dsentence);
   }
}
