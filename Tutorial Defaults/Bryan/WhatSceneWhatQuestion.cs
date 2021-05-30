using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhatSceneWhatQuestion: MonoBehaviour
{
    public int sceneNumber;

    void Start() {
        // sceneNumber = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("SceneManager");
        Debug.Log(sceneNumber);
        DontDestroyOnLoad(transform.gameObject);
    } 
}
