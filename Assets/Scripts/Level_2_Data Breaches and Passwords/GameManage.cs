using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// This is the script for the main manager file for L2QAScene.
/// 
/// It dynamically handles the outcome of the response chosen by the user(true/false). It generates questions in a random sequence, loads a new question after a short waiting period, and then transitions to the next scene once the user has answered all questions.
public class GameManage : MonoBehaviour
{
 public Qa[] qas;
 private static List<Qa> unansweredQ;

 private Qa currentQ;

 [SerializeField]
 private Text factText;

  [SerializeField]
 private Text trueAnswerText;

 [SerializeField]
 private Text falseAnswerText;

 [SerializeField]
 private Animator qanimator;


 [SerializeField]
 private float TimeBetweenQ = 3f;


 [SerializeField]
 private int completed = 0;

/// Start is called before the first frame update
 void Start(){

     if(unansweredQ == null || unansweredQ.Count == 0){
         unansweredQ = qas.ToList<Qa>();
     }

     SetCurrentQ();



 }
 
/// Sets the current question.
///
/// it displays a random question from the list. It also take in the response from the user and dynamically displays the text box corresponding to the chosen answer.
 void SetCurrentQ(){
int randomQIndex = Random.Range(0,unansweredQ.Count);
currentQ = unansweredQ[randomQIndex];
factText.text = currentQ.qa;

if(currentQ.isTrue){
    trueAnswerText.text = "Yes, you are correct! A good password should have numbers, symbols (@,#,_ etc.), and uppercase and lower case characters, and must not be “easy” to guess.";
        falseAnswerText.text = "Incorrect, be careful or you might get hacked again!";

    
}else{
        trueAnswerText.text = "Incorrect, be careful or you might get hacked again!";
    falseAnswerText.text = "Yes, you are correct! A good password should have numbers, symbols (@,#,_ etc.), and uppercase and lower case characters, and must not be “easy” to guess.";

}


 }
 
/// For Coroutine
 IEnumerator TransitionToNextQ(){
     unansweredQ.Remove(currentQ);

     yield return new WaitForSeconds(TimeBetweenQ);
     canOpenNew();


 }

///  Once the user has attempted all the questions in the list, it moves on to preparing for transition to the next scene. 
/// 
/// If the user has some unattempted questions, it will reload the current scene with an unattempted question.
 public void canOpenNew(){

if(unansweredQ.Count==0){
    EndLvl();

        return;
}

    
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
}
 
///  Responsible for displaying the next question.
 public void DisplayNextQ(){
completed++;
    if(completed==3){
        EndLvl();

        return;

    }
           

    StartCoroutine(TransitionToNextQ());
}

/// Called when user selects the "true" option.
 public void UserSelectTrue(){
     qanimator.SetTrigger("True");
    
     StartCoroutine(TransitionToNextQ());
 }

/// Called when user selects the "false" option.
  public void UserSelectFalse(){
      qanimator.SetTrigger("False");

          StartCoroutine(TransitionToNextQ());

 }

/// Called when the user has attempted all the questions. It is thus responsible for transitioning to the next scene with the help of LLoader.
 void EndLvl(){

string nowmoving = "";
FindObjectOfType<LLoader>().BeginNextScene(nowmoving);


}

}
