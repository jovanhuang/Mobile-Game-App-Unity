using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// This is the script for the level loader.
/// 
/// It is responsible for the animated transition from one scene to the next. It is used across the various scenes in level 2.
public class LLoader : MonoBehaviour
{
   
public Animator transition;

public float transitionTime = 2f;
   
///  Responsible for preparing to load the next **scene**. 
public void BeginNextScene(string passing){
    LoadNextLevel();
  
}

/// Responsible for starting the coroutine to load the next **scene**.
    public void LoadNextLevel(){
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

/// Responsible for preparing to load the next **level**. 
public void BeginNextLevel(string temp){
    LoadNewLevel();
  
}

/// Responsible for loading the next **level**.
    public void LoadNewLevel(){
   
    SceneManager.LoadScene("Game");

    }

/// For Coroutine
/// 
/// @param levelIndex allows the LLoader to load the scene with index levelIndex.
    IEnumerator LoadLevel(int levelIndex){
transition.SetTrigger("Start");
yield return new WaitForSeconds(transitionTime);

SceneManager.LoadScene(levelIndex);
    }
}
