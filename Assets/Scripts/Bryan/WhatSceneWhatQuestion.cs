using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// WhatSceneWhatQuestion class loads specific question bank based on previous scene
public class WhatSceneWhatQuestion: MonoBehaviour
{
    /// @param sceneNumber is the value stored in game object "variable"
    public int sceneNumber;

    /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// Start function here invokes don't destroy variable when transiting scenes
    /// If current scene is "Introduction" scene then destroy game object "Variable"
    void Start() {
        DontDestroyOnLoad(transform.gameObject);
        if (SceneManager.GetActiveScene ().name == "Introduction") 
        {
            Destroy(this.gameObject);
        }  
    } 

    /// Awake is called when the script instance is being loaded.
    /// Awake function is invoked if scene is "Introduction" scene then destroy game object "Variable"
    void Awake() {
        if (SceneManager.GetActiveScene ().name == "Introduction") 
        {
            Destroy(this.gameObject);
        }
    }

    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// Update function is invoked if scene is "Introduction" scene then destroy game object "Variable"
    void Update() {
        if (SceneManager.GetActiveScene ().name == "Introduction") 
        {
            Destroy(this.gameObject);
        }
    }
}
